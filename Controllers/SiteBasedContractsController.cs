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
    public class SiteBasedContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiteBasedContractsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SiteBasedContracts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SiteBasedContracts.ToListAsync());
        }

        // GET: SiteBasedContracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteBasedContracts = await _context.SiteBasedContracts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteBasedContracts == null)
            {
                return NotFound();
            }

            return View(siteBasedContracts);
        }

        // GET: SiteBasedContracts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SiteBasedContracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FormName,active")] SiteBasedContracts siteBasedContracts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siteBasedContracts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteBasedContracts);
        }

        // GET: SiteBasedContracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteBasedContracts = await _context.SiteBasedContracts.FindAsync(id);
            if (siteBasedContracts == null)
            {
                return NotFound();
            }
            return View(siteBasedContracts);
        }

        // POST: SiteBasedContracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FormName,active")] SiteBasedContracts siteBasedContracts)
        {
            if (id != siteBasedContracts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siteBasedContracts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteBasedContractsExists(siteBasedContracts.Id))
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
            return View(siteBasedContracts);
        }

        // GET: SiteBasedContracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteBasedContracts = await _context.SiteBasedContracts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteBasedContracts == null)
            {
                return NotFound();
            }

            return View(siteBasedContracts);
        }

        // POST: SiteBasedContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siteBasedContracts = await _context.SiteBasedContracts.FindAsync(id);
            if (siteBasedContracts != null)
            {
                _context.SiteBasedContracts.Remove(siteBasedContracts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteBasedContractsExists(int id)
        {
            return _context.SiteBasedContracts.Any(e => e.Id == id);
        }
    }
}
