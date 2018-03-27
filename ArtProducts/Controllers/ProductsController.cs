using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtProducts.Data;
using System;

namespace ArtProducts.Controllers
{

    [Route("api/[Controller]")] //attributed route ... this is called in the Angular app 
    public class ProductsController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<ProductsController> _logger;

       
        public ProductsController(IDutchRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        [HttpGet] //Http Get attribute 
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
            
        }

    }
}
