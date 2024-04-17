using Microsoft.AspNetCore.Mvc;

namespace Graphics_Asp_MVC.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Public/Index.cshtml");
        }

        public IActionResult FormsArchives()
        {
            return View("~/Views/Public/FormsArchives.cshtml");
        }

        public IActionResult TemplatesLogos()
        {
            return View("~/Views/Public/TemplatesLogos.cshtml");
        }
    }
}
