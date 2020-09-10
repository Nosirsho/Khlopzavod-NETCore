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
    public class BuntsController : Controller
    {
        private readonly ZavodContext _context;

        public BuntsController(ZavodContext context)
        {
            _context = context;
        }

        // GET: Bunts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bunt.ToListAsync());
        }

        // GET: Bunts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bunt = await _context.Bunt
                .FirstOrDefaultAsync(m => m.BuntID == id);
            if (bunt == null)
            {
                return NotFound();
            }

            return View(bunt);
        }

        // GET: Bunts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bunts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuntID,Name")] Bunt bunt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bunt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bunt);
        }

        // GET: Bunts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bunt = await _context.Bunt.FindAsync(id);
            if (bunt == null)
            {
                return NotFound();
            }
            return View(bunt);
        }

        // POST: Bunts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuntID,Name")] Bunt bunt)
        {
            if (id != bunt.BuntID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bunt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuntExists(bunt.BuntID))
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
            return View(bunt);
        }

        // GET: Bunts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bunt = await _context.Bunt
                .FirstOrDefaultAsync(m => m.BuntID == id);
            if (bunt == null)
            {
                return NotFound();
            }

            return View(bunt);
        }

        // POST: Bunts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bunt = await _context.Bunt.FindAsync(id);
            _context.Bunt.Remove(bunt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuntExists(int id)
        {
            return _context.Bunt.Any(e => e.BuntID == id);
        }
    }
}
