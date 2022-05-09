using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace Portfolio.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

       

        

    }

   
}
