using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Graphics_Asp_MVC.Data;
using Graphics_Asp_MVC.Models;
using System.Dynamic;
//using AspNetCore;
using NuGet.DependencyResolver;

namespace Graphics_Asp_MVC.Controllers
{
    public class FormDownloadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormDownloadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("/district-forms/")]
        // GET: FormDownloads
        public ActionResult Index()
        {
            var formdownloads = _context.FormDownload.ToList();
            var indexofforms = _context.IndexOfForms.ToList();
            var sitebasedcontracts = _context.SiteBasedContracts.ToList();
            var currentevaluations = _context.CurrentEvaluations.ToList();

            var viewModel = new ViewModel()
            {
                _formdownload = formdownloads,
                _indexofforms = indexofforms,
                _sitebasedcontracts = sitebasedcontracts,
                _currentevaluations = currentevaluations,
            };

            return View("~/Views/Public/FormDownloads/Index.cshtml", viewModel);
        }

    }
}
