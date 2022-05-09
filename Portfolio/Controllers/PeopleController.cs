using Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Controllers
{

    public class PeopleController : Controller
    {

        int newId = 4;

        public IActionResult Index(string searchString)
        {
            List<Person> persons = new List<Person>();
            PeopleViewModel viewPeople = new PeopleViewModel();
            CreatePersonViewModel newPerson = new CreatePersonViewModel();

            viewPeople.peopleList = PeopleList._list;

            


            if (searchString != null)
            {
                persons = PeopleList._list.Where(p => p.Name.ToLower().Contains(searchString) || p.City.ToLower().Contains(searchString) || p.PhoneNumber.ToLower().Contains(searchString)).ToList();

                viewPeople.peopleList = persons;
                viewPeople.person = newPerson;

                return View(viewPeople);
            }


            return View(viewPeople);
        }

        public IActionResult Index2(string searchString)
        {
            List<Person> persons = new List<Person>();
            PeopleViewModel viewPeople = new PeopleViewModel();
            CreatePersonViewModel newPerson = new CreatePersonViewModel();

            viewPeople.peopleList = PeopleList._list;




            if (searchString != null)
            {
                persons = PeopleList._list.Where(p => p.Name.ToLower().Contains(searchString) || p.City.ToLower().Contains(searchString) || p.PhoneNumber.ToLower().Contains(searchString)).ToList();

                viewPeople.peopleList = persons;
                viewPeople.person = newPerson;

                return View(viewPeople);
            }


            return View(viewPeople);
        }

        [HttpPost]
        
        public IActionResult Index(CreatePersonViewModel person)
        {
            PeopleViewModel viewModel = new PeopleViewModel();
            

            

            if (ModelState.IsValid)
            {
                Person personView = new Person()
                {
                    Name = person.NewName,
                    City = person.NewCity,
                    PhoneNumber = person.NewPhone,
                    Id = newId,
                };

                PeopleList._list.Add(personView);
                newId++;
                viewModel.person = person;
                viewModel.peopleList = PeopleList._list;

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

            viewPeople.peopleList = PeopleList._list;

            int number = int.Parse(id);

            Person PersonToDelete = PeopleList._list.Find(x => x.Id == number);

            PeopleList._list.Remove(PersonToDelete);

            viewPeople.peopleList = PeopleList._list;


            return View("Index", viewPeople);
        }
    }
}
