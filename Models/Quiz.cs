using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RmzPlatform.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

       [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string QuestionText { get; set; }

       [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string OptionA { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string OptionB { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string OptionC { get; set; }

       [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string OptionD { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CorrectAnswer { get; set; } 

        // ✅ العلاقة مع اللغة
    
        public int LanguageId { get; set; }
          [ForeignKey("LanguageId")]
      public Language? Language { get; set; } 
    }
}