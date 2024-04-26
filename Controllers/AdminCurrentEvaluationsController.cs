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
    public class AdminCurrentEvaluationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminCurrentEvaluationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CurrentEvaluations
        [Route("/admin/current-evaluations/")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Admin/CurrentEvaluations/Index.cshtml", await _context.CurrentEvaluations.ToListAsync());
        }

        // GET: Admin/CurrentEvaluations/Details/5
        //[Route("/admin/current-evaluations/details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentEvaluations = await _context.CurrentEvaluations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentEvaluations == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/CurrentEvaluations/Details.cshtml",currentEvaluations);
        }

        // GET: AdminCurrentEvaluations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminCurrentEvaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FormName,active")] CurrentEvaluations currentEvaluations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentEvaluations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currentEvaluations);
        }

        // GET: AdminCurrentEvaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentEvaluations = await _context.CurrentEvaluations.FindAsync(id);
            if (currentEvaluations == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/CurrentEvaluations/Edit.cshtml", currentEvaluations);
        }

        // POST: AdminCurrentEvaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FormName,active")] CurrentEvaluations currentEvaluations)
        {
            if (id != currentEvaluations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentEvaluations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrentEvaluationsExists(currentEvaluations.Id))
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
            return View("~/Views/Admin/CurrentEvaluations/Edit.cshtml", currentEvaluations);
        }

        // GET: AdminCurrentEvaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentEvaluations = await _context.CurrentEvaluations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentEvaluations == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/CurrentEvaluations/Delete.cshtml", currentEvaluations);
        }

        // POST: AdminCurrentEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentEvaluations = await _context.CurrentEvaluations.FindAsync(id);
            if (currentEvaluations != null)
            {
                _context.CurrentEvaluations.Remove(currentEvaluations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrentEvaluationsExists(int id)
        {
            return _context.CurrentEvaluations.Any(e => e.Id == id);
        }
    }
}
