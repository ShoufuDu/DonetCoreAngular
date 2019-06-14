using Microsoft.AspNetCore.Mvc;
using SimpleGlossary.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace SimpleGlossary.Controllers{
    public class HomeController : Controller    {
        private DataContext context;

        public HomeController(DataContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()        {
            ViewBag.Message = "Glossary App";
            return View(context.Entries.First());
        }

        [Authorize]
        public string Protected()
        {
            return "You have been authenticated";
        }

    }
}
