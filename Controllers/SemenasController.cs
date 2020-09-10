using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KlopZavod.Data;
using KlopZavod.Models;

namespace KlopZavod.Controllers
{
    public class SemenasController : Controller
    {
        private readonly ZavodContext _context;

        public SemenasController(ZavodContext context)
        {
            _context = context;
        }

        // GET: Semenas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Semena.ToListAsync());
        }

        // GET: Semenas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semena = await _context.Semena
                .FirstOrDefaultAsync(m => m.SemenaID == id);
            if (semena == null)
            {
                return NotFound();
            }

            return View(semena);
        }

        // GET: Semenas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Semenas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SemenaID,Name")] Semena semena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(semena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(semena);
        }

        // GET: Semenas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semena = await _context.Semena.FindAsync(id);
            if (semena == null)
            {
                return NotFound();
            }
            return View(semena);
        }

        // POST: Semenas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SemenaID,Name")] Semena semena)
        {
            if (id != semena.SemenaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(semena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SemenaExists(semena.SemenaID))
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
            return View(semena);
        }

        // GET: Semenas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semena = await _context.Semena
                .FirstOrDefaultAsync(m => m.SemenaID == id);
            if (semena == null)
            {
                return NotFound();
            }

            return View(semena);
        }

        // POST: Semenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var semena = await _context.Semena.FindAsync(id);
            _context.Semena.Remove(semena);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SemenaExists(int id)
        {
            return _context.Semena.Any(e => e.SemenaID == id);
        }
    }
}
