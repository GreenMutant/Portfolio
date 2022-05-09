using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }

        public virtual ICollection<City> Cities { get; set; }

    }
}
