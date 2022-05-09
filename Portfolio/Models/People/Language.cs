using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        [Required]
        public string LanguageName { get; set; }

        public virtual ICollection<PersonLanguage> PersonLanguages { get; set; }
    }
}
