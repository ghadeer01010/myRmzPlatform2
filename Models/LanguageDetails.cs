using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RmzPlatform.Models
{
    public class LanguageDetails
    {
        [Key]
        public int Id { get; set; }

        public string? Overview { get; set; }     // نبذة عن اللغة
        public string? ImageUrl { get; set; }     // صورة تعبيرية

        // ✅ العلاقة مع Language
       
        public int LanguageId { get; set; }
 [ForeignKey("LanguageId")]
        public Language Language { get; set; } 
    }
}