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

            return View(viewModel);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formDownload = await _context.FormDownload
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formDownload == null)
            {
                return NotFound();
            }

            return View(formDownload);
        }

        // GET: FormDownloads/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FormType,FormNumber,FormName,FormUrl,active")] FormDownload formDownload)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formDownload);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formDownload);
        }

        // GET: FormDownloads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formDownload = await _context.FormDownload.FindAsync(id);
            if (formDownload == null)
            {
                return NotFound();
            }
            return View(formDownload);
        }

        // POST: FormDownloads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FormType,FormNumber,FormName,FormUrl,active")] FormDownload formDownload)
        {
            if (id != formDownload.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formDownload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormDownloadExists(formDownload.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(formDownload);
        }

        // GET: FormDownloads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formDownload = await _context.FormDownload
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formDownload == null)
            {
                return NotFound();
            }

            return View(formDownload);
        }

        // POST: FormDownloads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formDownload = await _context.FormDownload.FindAsync(id);
            if (formDownload != null)
            {
                _context.FormDownload.Remove(formDownload);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormDownloadExists(int id)
        {
            return _context.FormDownload.Any(e => e.Id == id);
        }
    }
}
