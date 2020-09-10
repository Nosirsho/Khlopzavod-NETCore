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
    public class AssocsController : Controller
    {
        private readonly ZavodContext _context;

        public AssocsController(ZavodContext context)
        {
            _context = context;
        }

        // GET: Assocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assoc.ToListAsync());
        }

        // GET: Assocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assoc = await _context.Assoc
                .FirstOrDefaultAsync(m => m.AssocID == id);
            if (assoc == null)
            {
                return NotFound();
            }

            return View(assoc);
        }

        // GET: Assocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssocID,Name,SocrName,Jamoat")] Assoc assoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assoc);
        }

        // GET: Assocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assoc = await _context.Assoc.FindAsync(id);
            if (assoc == null)
            {
                return NotFound();
            }
            return View(assoc);
        }

        // POST: Assocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssocID,Name,SocrName,Jamoat")] Assoc assoc)
        {
            if (id != assoc.AssocID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssocExists(assoc.AssocID))
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
            return View(assoc);
        }

        // GET: Assocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assoc = await _context.Assoc
                .FirstOrDefaultAsync(m => m.AssocID == id);
            if (assoc == null)
            {
                return NotFound();
            }

            return View(assoc);
        }

        // POST: Assocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assoc = await _context.Assoc.FindAsync(id);
            _context.Assoc.Remove(assoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssocExists(int id)
        {
            return _context.Assoc.Any(e => e.AssocID == id);
        }
    }
}
