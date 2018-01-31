using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Data;
using MyProject.Data.Entities;
using MyProject.ViewModels;
using System;
using System.Collections.Generic;

namespace MyProject.Controllers
{
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(IDutchRepository repository, ILogger<OrdersController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public IActionResult Get(bool includeItems=true)
        {
            try
            {
                var username = User.Identity.Name;

                var results = _repository.GetAllOrdersByUser(username, includeItems);
                return Ok(_mapper.Map<IEnumerable<Orders>, IEnumerable<OrderViewModel>>(results));
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get orders: {ex}"); //the $("string") is a new feature in C# 6.0 called Interpolated Strings 
                return BadRequest($"Failed to get orders");
            }
        }

        [HttpGet("{id:int}")] // just adding an argument to the URL that is specified above in the controller decalration
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetOrderById(User.Identity.Name, id);
                
                if (order != null) return Ok(_mapper.Map<Orders, OrderViewModel>(order));
                return Ok();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest($"Failed to get orders");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            //add it to the db
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = _mapper.Map<OrderViewModel, Orders>(model);

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    _repository.AddEntity(newOrder);
                    if (_repository.SaveAll())
                    {

                        //Created method is a 201, rather than Ok() which is 200
                        //if you created a new object you need to return "Created", which specifies where it is on the API and pass back the data 
                        return Created($"/api/orders/{newOrder.Id}", _mapper.Map<Orders, OrderViewModel>(newOrder));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to add a new order: {ex}");
            }
            return BadRequest($"Failed to add new order");

        }

    }
}
