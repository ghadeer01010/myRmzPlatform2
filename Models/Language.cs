using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RmzPlatform.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        // ✅ العلاقات:
        public ICollection<Quiz> Quiz { get; set; } = new List<Quiz>();
        public ICollection<Result> Result { get; set; } = new List<Result>();

        public LanguageDetails? LanguageDetails { get; set; } 
    }
}