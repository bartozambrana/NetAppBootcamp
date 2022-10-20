using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssessmentApplication.Context;
using AssessmentApplication.Models;

namespace AssessmentApplication.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly bartolomeZambranaPerezDatabaseContext _context;

        public ClaimsController(bartolomeZambranaPerezDatabaseContext context)
        {
            _context = context;
        }

        // GET: Claims
        public async Task<IActionResult> Index()
        {
            var bartolomeZambranaPerezDatabaseContext = _context.Claims.Include(c => c.Vehicle);
            return View(await bartolomeZambranaPerezDatabaseContext.ToListAsync());
        }

        // GET: Claims/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Claims == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims
                .Include(c => c.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // GET: Claims/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id");
            return View();
        }

        // POST: Claims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Status,Date,VehicleId")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", claim.VehicleId);
            return View(claim);
        }

        // GET: Claims/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Claims == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", claim.VehicleId);
            return View(claim);
        }

        // POST: Claims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Description,Status,Date,VehicleId")] Claim claim)
        {
            if (id != claim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimExists(claim.Id))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", claim.VehicleId);
            return View(claim);
        }

        // GET: Claims/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Claims == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims
                .Include(c => c.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Claims == null)
            {
                return Problem("Entity set 'bartolomeZambranaPerezDatabaseContext.Claims'  is null.");
            }
            var claim = await _context.Claims.FindAsync(id);
            if (claim != null)
            {
                _context.Claims.Remove(claim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimExists(long id)
        {
          return _context.Claims.Any(e => e.Id == id);
        }
    }
}
