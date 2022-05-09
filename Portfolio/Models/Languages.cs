using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Languages
    {
       
        public string CountryId { get; set; }

        public PersonE2 Persons { get; set; }

        public Country Country { get; set; }

        public string Language { get; set; }
    }
}
