using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public int CountryId { get; set; }

        [Required]
        public Country Country { get; set; }
        public virtual ICollection<Person> People { get; set; }

    }
}