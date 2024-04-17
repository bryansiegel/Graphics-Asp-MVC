using Microsoft.AspNetCore.Mvc;

namespace Graphics_Asp_MVC.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Public/Index.cshtml");
        }
    }
}
