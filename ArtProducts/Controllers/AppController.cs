using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArtProducts.ViewModels;
using ArtProducts.Services;
using ArtProducts.Data;
using Microsoft.AspNetCore.Authorization;

namespace ArtProducts.Controllers
{
    public class AppController : Controller
    {

        private readonly IMailService _mailService;
        public readonly IDutchRepository _repository;

        public AppController(IMailService mailService, IDutchRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

     
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("kokarim@msn.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                //show errors
            }
        
            return View();
        } 


        public IActionResult About()
        {
            return View();
        }

        [Authorize]
        public IActionResult Shop()
        {
            
            return View();
        }

        


    }//AppController
}//namepace
