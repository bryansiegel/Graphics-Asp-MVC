using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Graphics_Asp_MVC.Data;
using Graphics_Asp_MVC.Models;

namespace Graphics_Asp_MVC.Controllers
{
    public class CurrentEvaluationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurrentEvaluationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Public/CurrentEvaluations
        [Route("/current-evaluations")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Public/CurrentEvaluations/Index.cshtml", await _context.CurrentEvaluations.ToListAsync());
        }

    }
}
