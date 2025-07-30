using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RmzPlatform.Data;
using RmzPlatform.Models;
using System.Linq;

namespace RmzPlatform.Controllers
{
    public class RmzController : Controller
    {
        private readonly AppDbContext _context;

        public RmzController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ الصفحة الرئيسية
        public IActionResult Index()
        {
            return View();
        }

        // ✅ صفحة اللغات
        public async Task<IActionResult> Languages()
        {
            var languages = await _context.Language
                .Include(l => l.Quiz)
                .ToListAsync();

            return View(languages);
        }

        // ✅ صفحة بدء الاختبار
        public async Task<IActionResult> Start(int languageId)
        {
            var language = await _context.Language.FindAsync(languageId);
            if (language == null)
                return NotFound();

            var quiz = await _context.Quiz
                .Where(q => q.LanguageId == languageId)
                .ToListAsync();

            ViewBag.LanguageName = language.Name;
            return View(quiz);
        }

        // ✅ إرسال الإجابات ومعالجة النتيجة
       [HttpPost]
public async Task<IActionResult> SubmitQuiz(int languageId, Dictionary<int, string> answers)
{
    var quizzes = await _context.Quiz
        .Where(q => q.LanguageId == languageId)
        .ToListAsync();

    int correctCount = 0;

    foreach (var quiz in quizzes)
    {
if (answers.TryGetValue(quiz.Id, out string userAnswer))
{
    if (userAnswer == quiz.CorrectAnswer)
    {
        correctCount++;
    }
}

    }

    int totalQuestions = quizzes.Count;
    int score = (int)((double)correctCount / totalQuestions * 100);

    var language = await _context.Language.FindAsync(languageId);
    TempData["Score"] = score;
    TempData["Correct"] = correctCount;
    TempData["Total"] = totalQuestions;
    TempData["LanguageName"] = language?.Name;

    return RedirectToAction("Result");
}

        // ✅ صفحة عرض النتيجة
        public IActionResult Result()
        {
            return View();
        }

        // ✅ صفحة "عن الموقع"
        public IActionResult About()
        {
            return View();
        }
    }
}