    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RmzPlatform.Data;
    using RmzPlatform.Models;
    using Microsoft.AspNetCore.Authorization;

    namespace RmzPlatform.Controllers
    {
        public class AdminController : Controller
        {
            private readonly AppDbContext _context;

            public AdminController(AppDbContext context)
            {
                _context = context;
            }

            // =================== الصفحة الرئيسية ===================
            public IActionResult Index()
            {
                return View();
            }

            // =================== إدارة اللغات ===================

            // عرض جميع اللغات
            public async Task<IActionResult> Language()
            {
                var language = await _context.Language.ToListAsync();
                return View(language);
            }
    [HttpGet]
            // عرض نموذج إنشاء لغة جديدة
            public IActionResult CreateLanguage()
            {
                return View();
            }

        
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> CreateLanguage(Language language)
            {
                if (ModelState.IsValid)
                {
                    _context.Language.Add(language);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Language)); 
                }
                return View(language);
            }

            // عرض نموذج تعديل لغة
            public async Task<IActionResult> EditLanguage(int id)
            {
                var language = await _context.Language.FindAsync(id);
                if (language == null) return NotFound();
                return View(language);
            }

        
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> EditLanguage(int id, Language language)
            {
                if (id != language.Id) return NotFound();

                if (ModelState.IsValid)
                {
                    _context.Update(language);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Language));
                }

                return View(language);
            }

            // حذف لغة
            public async Task<IActionResult> DeleteLanguage(int id)
            {
                var language = await _context.Language.FindAsync(id);
                if (language != null)
                {
                    _context.Language.Remove(language);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Language));
            }

            // =================== إدارة الأسئلة ===================

            // عرض جميع الأسئلة
            public async Task<IActionResult> Quiz()
            {
                var quiz = await _context.Quiz.Include(q => q.Language).ToListAsync();
                return View(quiz);
            }

            // عرض نموذج إنشاء سؤال
            public IActionResult CreateQuiz()
            {
                ViewBag.Language = _context.Language.ToList();
                return View();
            }

            
         [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> CreateQuiz(Quiz quiz)
{
    if (ModelState.IsValid)
    {
        _context.Quiz.Add(quiz);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Quiz));
    }

    // إعادة تحميل اللغات إذا فشل النموذج
    ViewBag.Language = await _context.Language.ToListAsync();
    return View(quiz);
}

public async Task<IActionResult> EditQuiz(int id)
{
    var quiz = await _context.Quiz.FindAsync(id);
    if (quiz == null)
        return NotFound();

    ViewBag.Language = await _context.Language.ToListAsync();
    return View(quiz);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> EditQuiz(Quiz quiz)
{
    if (ModelState.IsValid)
    {
        _context.Quiz.Update(quiz);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Quiz));
    }

    ViewBag.Language = await _context.Language.ToListAsync();
    return View(quiz);
}
            // حذف سؤال
            public async Task<IActionResult> DeleteQuiz(int id)
            {
                var quiz = await _context.Quiz.FindAsync(id);
                if (quiz != null)
                {
                    _context.Quiz.Remove(quiz);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Quiz));
            }

            // =================== إدارة النتائج ===================

            // عرض جميع النتائج
            public async Task<IActionResult> Result()
            {
                var result = await _context.Result.Include(r => r.Language).ToListAsync();
                return View(result);
            }

            // عرض تفاصيل نتيجة
            public async Task<IActionResult> ResultDetails(int id)
            {
                var result = await _context.Result.Include(r => r.Language).FirstOrDefaultAsync(r => r.Id == id);
                if (result == null) return NotFound();
                return View(result);
            }

            // حذف نتيجة
            public async Task<IActionResult> DeleteResult(int id)
            {
                var result = await _context.Result.FindAsync(id);
                if (result != null)
                {
                    _context.Result.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Result));
            }
        }
    }