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
    public class IndexOfFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IndexOfFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IndexOfForms
        [Route("index-of-forms")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.IndexOfForms.ToListAsync());
        }

        // GET: IndexOfForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indexOfForms = await _context.IndexOfForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indexOfForms == null)
            {
                return NotFound();
            }

            return View(indexOfForms);
        }

        // GET: IndexOfForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IndexOfForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FormName,active")] IndexOfForms indexOfForms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indexOfForms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(indexOfForms);
        }

        // GET: IndexOfForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indexOfForms = await _context.IndexOfForms.FindAsync(id);
            if (indexOfForms == null)
            {
                return NotFound();
            }
            return View(indexOfForms);
        }

        // POST: IndexOfForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FormName,active")] IndexOfForms indexOfForms)
        {
            if (id != indexOfForms.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indexOfForms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndexOfFormsExists(indexOfForms.Id))
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
            return View(indexOfForms);
        }

        // GET: IndexOfForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indexOfForms = await _context.IndexOfForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (indexOfForms == null)
            {
                return NotFound();
            }

            return View(indexOfForms);
        }

        // POST: IndexOfForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var indexOfForms = await _context.IndexOfForms.FindAsync(id);
            if (indexOfForms != null)
            {
                _context.IndexOfForms.Remove(indexOfForms);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndexOfFormsExists(int id)
        {
            return _context.IndexOfForms.Any(e => e.Id == id);
        }
    }
}
