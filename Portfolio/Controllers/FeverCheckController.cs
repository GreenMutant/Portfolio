using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class FeverCheckController : Controller
    {
        public IActionResult GetInfo()
        {
            ViewBag.Message = FeverCheckModel.WriteMessage();
            return View();
        }
        [HttpPost]
        public IActionResult GetInfo(string temp)
        {
            FeverCheckModel model = new FeverCheckModel();
            ViewBag.Message = model.CheckFever(temp);
            return View();
        }
    }
}
