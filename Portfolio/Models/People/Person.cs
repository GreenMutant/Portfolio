using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Portfolio.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        
        public virtual ICollection<Country> Languages { get; set; }
    }
}