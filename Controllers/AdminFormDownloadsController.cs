using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Graphics_Asp_MVC.Data;
using Graphics_Asp_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Graphics_Asp_MVC.Controllers
{
    [Authorize]
    public class AdminFormDownloadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminFormDownloadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/FormDownloads
        [Route("/admin/form-downloads/")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Admin/FormDownloads/Index.cshtml", await _context.FormDownload.ToListAsync());
        }

        // GET: AdminFormDownloads/Details/5
        [Route("/admin/form-downloads/details/{id}")]
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

            return View("~/Views/Admin/FormDownloads/Details.cshtml", formDownload);
        }

        // GET: Admin/FormDownloads/Create
        public IActionResult Create()
        {
            return View("~/Views/Admin/FormDownloads/Create.cshtml");
        }

        // POST: AdminFormDownloads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            return View("~/Views/Admin/FormDownloads/Create.cshtml", formDownload);
        }

        // GET: Admin/FormDownloads/Edit/5
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
            return View("~/Views/Admin/FormDownloads/Edit.cshtml", formDownload);
        }

        // POST: AdminFormDownloads/Edit/5
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
            return View("~/Views/Admin/FormDownloads/Edit.cshtml", formDownload);
        }

        // GET: AdminFormDownloads/Delete/5
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

            return View("~/Views/Admin/FormDownloads/Delete.cshtml", formDownload);
        }

        // POST: AdminFormDownloads/Delete/5
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
