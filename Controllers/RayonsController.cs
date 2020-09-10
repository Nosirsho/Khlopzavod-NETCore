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
    public class RayonsController : Controller
    {
        private readonly ZavodContext _context;

        public RayonsController(ZavodContext context)
        {
            _context = context;
        }

        // GET: Rayons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rayon.ToListAsync());
        }

        // GET: Rayons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rayon = await _context.Rayon
                .FirstOrDefaultAsync(m => m.RayonID == id);
            if (rayon == null)
            {
                return NotFound();
            }

            return View(rayon);
        }

        // GET: Rayons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rayons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RayonID,Name")] Rayon rayon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rayon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rayon);
        }

        // GET: Rayons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rayon = await _context.Rayon.FindAsync(id);
            if (rayon == null)
            {
                return NotFound();
            }
            return View(rayon);
        }

        // POST: Rayons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RayonID,Name")] Rayon rayon)
        {
            if (id != rayon.RayonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rayon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RayonExists(rayon.RayonID))
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
            return View(rayon);
        }

        // GET: Rayons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rayon = await _context.Rayon
                .FirstOrDefaultAsync(m => m.RayonID == id);
            if (rayon == null)
            {
                return NotFound();
            }

            return View(rayon);
        }

        // POST: Rayons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rayon = await _context.Rayon.FindAsync(id);
            _context.Rayon.Remove(rayon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RayonExists(int id)
        {
            return _context.Rayon.Any(e => e.RayonID == id);
        }
    }
}
