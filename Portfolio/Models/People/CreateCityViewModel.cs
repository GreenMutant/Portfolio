using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.Entities
{
    public class CreateCityViewModel
    {
        [Required]
        public string NewCityName { get; set; }


    }
}
