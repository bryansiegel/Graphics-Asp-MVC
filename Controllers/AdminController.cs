using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graphics_Asp_MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        [Route("admin/dashboard/")]
        public ActionResult Index()
        {
            return View("~/Views/Admin/Dashboard.cshtml");
        }

    }
}
