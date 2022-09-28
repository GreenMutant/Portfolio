using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class PersonLanguage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Person Person { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        [Required]
        public Language Language { get; set; }
    }
}
