using Microsoft.AspNetCore.Mvc;

namespace Graphics_Asp_MVC.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Public/Index.cshtml");
        }

        [Route("form-archives")]
        public IActionResult FormsArchives()
        {
            return View("~/Views/FormDownloads/Index.cshtml");
        }

        [ActionName("templates-logos")]
        public IActionResult TemplatesLogos()
        {
            return View("~/Views/Public/TemplatesLogos.cshtml");
        }
    }
}
