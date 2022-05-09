using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Portfolio.Models
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(15)]
        public string NewName { get; set; }

        [Required]
        [StringLength(20)]
        public string NewCity { get; set; }

        [Required]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        public string NewPhone { get; set; }

        


    }
}