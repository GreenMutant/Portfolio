using Portfolio.Data;
using Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Controllers
{
    public class CityDBController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CityController(ApplicationDbContext config)
        {
            _context = config;
        }
        public IActionResult Index()
        {
            List<City> citiesList = _context.Cities.ToList();

            return View(citiesList);


        }

        public IActionResult City()
        {
            ViewBag.Countries = new SelectList(_context.Countries, "CountryName", "CountryName");

            return View();
        }


        [HttpPost]
        public IActionResult City(string CityName, string CountryName)
        {
            Country addCountry = _context.Countries.FirstOrDefault(c => c.CountryName == CountryName);

            City city = new City()
            {
                CityName = CityName,
                CountryId = addCountry.CountryId,
                
            };

            _context.Cities.Add(city);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Delete(City city)
        {
            City deleteCity = _context.Cities.Find(city.CityId);

            _context.Cities.Remove(deleteCity);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
