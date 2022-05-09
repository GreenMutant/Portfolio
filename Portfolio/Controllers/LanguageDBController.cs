using Portfolio.Data;
using Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Controllers
{
    public class LanguageDBController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LanguageDBController(ApplicationDbContext config)
        {
            _context = config;
        }
        public IActionResult Index()
        {
            List<Language> LanguagesList = _context.Languages.ToList();

            return View(LanguagesList);

        }

        public IActionResult Language()
        {
            ViewBag.Languages = new SelectList(_context.Languages, "LanguageName", "LanguageName");

            return View();
        }

        [HttpPost]
        public IActionResult Language(string LanguageName)
        {

            Language language = new Language()
            {
                LanguageName = LanguageName,

            };

            _context.Languages.Add(language);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Delete(Language language)
        {

            Language deleteLanguage = _context.Languages.Find(language.LanguageId);

            _context.Languages.Remove(deleteLanguage);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}