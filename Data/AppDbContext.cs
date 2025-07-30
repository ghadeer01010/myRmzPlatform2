using Microsoft.EntityFrameworkCore;
using RmzPlatform.Models;
using RmzPlatform.Data;
namespace RmzPlatform.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // الجداول في قاعدة البيانات
        public DbSet<Language> Language { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<LanguageDetails> LanguageDetails { get; set; }

        // إعداد العلاقات 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // علاقة Quiz ← Language (كل سؤال مرتبط بلغة واحدة)
            modelBuilder.Entity<Quiz>()
                .HasOne(q => q.Language)
                .WithMany(l => l.Quiz)
                .HasForeignKey(q => q.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);

            // علاقة Result ← Language (كل نتيجة مرتبطة بلغة واحدة)
            modelBuilder.Entity<Result>()
                .HasOne(r => r.Language)
                .WithMany(l => l.Result)
                .HasForeignKey(r => r.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);

            // علاقة LanguageDetails ← Language (تفاصيل لغة واحدة)
            modelBuilder.Entity<LanguageDetails>()
                .HasOne(ld => ld.Language)
                .WithOne(l => l.LanguageDetails)
                .HasForeignKey<LanguageDetails>(ld => ld.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}