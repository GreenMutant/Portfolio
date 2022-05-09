using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class GuessingGameController : Controller
    {
        

       
       

        
        public IActionResult SetSession()
        {
            Random rd = new Random();
            int randNum = rd.Next(1, 100);
            HttpContext.Session.SetInt32("randNumSession", randNum);
            return View();
        }

        [HttpPost]
        public IActionResult SetSession(int numericInput)
        {
            

            HttpContext.Session.SetInt32("numSession", numericInput);

            if (numericInput == HttpContext.Session.GetInt32("randNumSession"))

                ViewBag.Message = "Congratulations";

            if (numericInput > HttpContext.Session.GetInt32("randNumSession"))

                ViewBag.Message = "Hidden number is smaller";

            if (numericInput < HttpContext.Session.GetInt32("randNumSession"))

                ViewBag.Message = "Hidden number is greater";

            return View();
        }
       
        public IActionResult GetSession()
        {
            ViewBag.SessionNum = HttpContext.Session.GetInt32("numSession");

            return View();
        }

       
        
           

        
        }
}
