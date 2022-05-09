using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Portfolio.Models.People;

namespace Portfolio.Models
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(15)]
        public string NewName { get; set; }

        [Required]
        [StringLength(20)]
        public string CityId { get; set; }

        [Required]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        public string NewPhone { get; set; }


        public virtual ICollection<PersonLanguage> languages { get; set; }

    }
}