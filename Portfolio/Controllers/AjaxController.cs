using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class AjaxController : Controller
    {
        
        public static PeopleViewModel people = new PeopleViewModel();

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetPeople()
        {
            return PartialView("_PeopleList", people.PeopleList);
        }

        public ActionResult GetDetails(string index)
        {
            int inputToInt = -1;
            if (int.TryParse(index, out inputToInt))
            {
                if (inputToInt < people.PeopleList.Count)
                {
                    return PartialView("_PersonDetails", people.PeopleList[inputToInt]);
                }
            }

            return PartialView("_PeopleList", people.PeopleList);
        }

        public ActionResult RemovePerson(string index)
        {
            int inputToInt = -1;
            if (int.TryParse(index, out inputToInt))
            {
                if (inputToInt < people.PeopleList.Count)
                {
                    people.PeopleList.RemoveAt(inputToInt);
                }
            }

            return PartialView("_PeopleList", people.PeopleList);
        }

        
    }
}