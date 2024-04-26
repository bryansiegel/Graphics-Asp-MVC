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
    
    public class DownloadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DownloadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Downloads
        [Route("district-downloads")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Downloads.ToListAsync());
        }

        // GET: Downloads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var downloads = await _context.Downloads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (downloads == null)
            {
                return NotFound();
            }

            return View(downloads);
        }

        // GET: Downloads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Downloads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,Form,active")] Downloads downloads)
        {
            if (ModelState.IsValid)
            {
                _context.Add(downloads);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(downloads);
        }

        // GET: Downloads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var downloads = await _context.Downloads.FindAsync(id);
            if (downloads == null)
            {
                return NotFound();
            }
            return View(downloads);
        }

        // POST: Downloads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,Form,active")] Downloads downloads)
        {
            if (id != downloads.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(downloads);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DownloadsExists(downloads.Id))
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
            return View(downloads);
        }

        // GET: Downloads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var downloads = await _context.Downloads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (downloads == null)
            {
                return NotFound();
            }

            return View(downloads);
        }

        // POST: Downloads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var downloads = await _context.Downloads.FindAsync(id);
            if (downloads != null)
            {
                _context.Downloads.Remove(downloads);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DownloadsExists(int id)
        {
            return _context.Downloads.Any(e => e.Id == id);
        }
    }
}
