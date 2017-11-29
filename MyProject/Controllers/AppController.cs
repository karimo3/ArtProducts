using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
    public class AppController : Controller
    {
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
            return View();
        } 


        public IActionResult About()
        {
            return View();
        }






    }//AppController
}//namepace
