using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RmzPlatform.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المستخدم مطلوب")]
        public string UserName { get; set; } = null!;

        [Required]
        public int Score { get; set; }

        [Required]
        public int CorrectAnswers { get; set; }

        [Required]
        public int TotalQuestions { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        // ✅ العلاقة مع اللغة
        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public Language Language { get; set; } 
    }
}