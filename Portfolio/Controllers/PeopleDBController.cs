using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Models;
using Portfolio.Data;

namespace Portfolio.Controllers
{
    public class PeopleDBController : Controller
    {
        

        private readonly ApplicationDbContext _context;

        public PeopleDBController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(string searchString)
        {
            List<Person> persons = new List<Person>();
            PeopleViewModel viewPeople = new PeopleViewModel();
            CreatePersonViewModel newPerson = new CreatePersonViewModel();

            viewPeople.peopleList = _context.People.ToList();




            if (searchString != null)
            {
                persons = PeopleList._list.Where(p => p.Name.Contains(searchString) || p.City.CityName.Contains(searchString) || p.PhoneNumber.Contains(searchString)).ToList();

                viewPeople.peopleList = persons;
                viewPeople.person = newPerson;

                return View(viewPeople);
            }


            return View(viewPeople);
        }
        [HttpPost]
        public IActionResult Index(CreatePersonViewModel person, string CityName)
        {
            PeopleViewModel viewModel = new PeopleViewModel();
            CreatePersonViewModel newPerson = new CreatePersonViewModel();

            ViewBag.Cities = new SelectList(_context.Cities, "CityName", "CityName");

            City cityToAdd = _context.Cities.FirstOrDefault(c => c.CityName == CityName);

            int newId = _context.People.Count() + 1;

            if (ModelState.IsValid)
            {

                Person personView = new Person()
                {

                    Name = person.NewName,
                    CityId = cityToAdd.CityId,
                    PhoneNumber = person.NewPhone,
                    Id = newId,
                };

                _context.People.Add(personView);
                _context.SaveChanges();

                viewModel.person = person;
                viewModel.peopleList = _context.People.ToList();

                return View(viewModel);

            }

            viewModel.peopleList = PeopleList._list;
            viewModel.person = person;

            return View(viewModel);
        }

        public IActionResult DeletePerson(string id)
        {
            List<Person> persons = new List<Person>();
            PeopleViewModel viewPeople = new PeopleViewModel();
            CreatePersonViewModel newPerson = new CreatePersonViewModel();

            viewPeople.peopleList = _context.People.ToList();

            int number = int.Parse(id);

            Person PersonToDelete = _context.People.FirstOrDefault(x => x.Id == number);

            _context.People.Remove(PersonToDelete);
            _context.SaveChanges();
            viewPeople.peopleList = _context.People.ToList();


            return View("Index", viewPeople);
        }
    }
}
