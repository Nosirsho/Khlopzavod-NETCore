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
    public class PartiyasController : Controller
    {
        private readonly ZavodContext _context;

        public PartiyasController(ZavodContext context)
        {
            _context = context;
        }

        // GET: Partiyas
        public async Task<IActionResult> Index()
        {
            var zavodContext = _context.Partiya.Include(p => p.Bunt).Include(p => p.Semena);
            return View(await zavodContext.ToListAsync());
        }

        // GET: Partiyas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partiya = await _context.Partiya
                .Include(p => p.Bunt)
                .Include(p => p.Semena)
                .FirstOrDefaultAsync(m => m.PartiyaID == id);
            if (partiya == null)
            {
                return NotFound();
            }

            return View(partiya);
        }

        // GET: Partiyas/Create
        public IActionResult Create()
        {

            ViewData["BuntID"] = new SelectList(_context.Bunt, "BuntID", "Name");
            ViewData["SemenaID"] = new SelectList(_context.Semena, "SemenaID", "Name");
            return View();
        }

        // POST: Partiyas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartiyaID,NomerPart,BuntID,SemenaID,Vid,Sort,Sbor")] Partiya partiya)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partiya);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuntID"] = new SelectList(_context.Bunt, "BuntID", "BuntID", partiya.BuntID);
            ViewData["SemenaID"] = new SelectList(_context.Semena, "SemenaID", "SemenaID", partiya.SemenaID);
            return View(partiya);
        }

        // GET: Partiyas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partiya = await _context.Partiya.FindAsync(id);
            if (partiya == null)
            {
                return NotFound();
            }
            ViewData["BuntID"] = new SelectList(_context.Bunt, "BuntID", "Name", partiya.BuntID);
            ViewData["SemenaID"] = new SelectList(_context.Semena, "SemenaID", "Name", partiya.SemenaID);
            return View(partiya);
        }

        // POST: Partiyas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartiyaID,NomerPart,BuntID,SemenaID,Vid,Sort,Sbor")] Partiya partiya)
        {
            if (id != partiya.PartiyaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partiya);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartiyaExists(partiya.PartiyaID))
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
            ViewData["BuntID"] = new SelectList(_context.Bunt, "BuntID", "BuntID", partiya.BuntID);
            ViewData["SemenaID"] = new SelectList(_context.Semena, "SemenaID", "SemenaID", partiya.SemenaID);
            return View(partiya);
        }

        // GET: Partiyas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partiya = await _context.Partiya
                .Include(p => p.Bunt)
                .Include(p => p.Semena)
                .FirstOrDefaultAsync(m => m.PartiyaID == id);
            if (partiya == null)
            {
                return NotFound();
            }

            return View(partiya);
        }

        // POST: Partiyas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partiya = await _context.Partiya.FindAsync(id);
            _context.Partiya.Remove(partiya);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartiyaExists(int id)
        {
            return _context.Partiya.Any(e => e.PartiyaID == id);
        }
    }
}
