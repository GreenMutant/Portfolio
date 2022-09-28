using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [Required]
        public Country Country { get; set; }
        public virtual ICollection<Person> People { get; set; }

    }
}