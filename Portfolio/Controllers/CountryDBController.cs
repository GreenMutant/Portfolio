using Portfolio.Data;
using Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext config)
        {
            _context = config;
        }
        public IActionResult Index()
        {
            List<Country> countriesList = _context.Countries.ToList();


            return View(countriesList);
        }
        public IActionResult Country()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Country(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        public IActionResult Delete(Country country)
        {
            Country deteleCountry = _context.Countries.Find(country.CountryId);


            _context.Countries.Remove(deteleCountry);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}