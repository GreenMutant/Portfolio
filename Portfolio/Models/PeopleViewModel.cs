using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Portfolio.Data;

namespace Portfolio.Models
{
    public class PeopleCreateViewModel
    {
        public int Id { get; set; }

        [Required, Display(Name = "Name")]
        public string Name { get; set; }

        [Required, Display(Name = "City")]
        public string City { get; set; }

        [Required, Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; }
    }

    public class PeopleViewModel
    {
        public PeopleCreateViewModel CreateModel { get; set; }

        public string Filter { get; set; }

        public IEnumerable<Person> People { get; set; }

        public PeopleViewModel()
        {
            CreateModel = new PeopleCreateViewModel();
        }


    }

   

}