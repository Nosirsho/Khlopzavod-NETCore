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
    public class PKvitanciyasController : Controller
    {
        private readonly ZavodContext _context;

        public PKvitanciyasController(ZavodContext context)
        {
            _context = context;
        }

        // GET: PKvitanciyas
        public async Task<IActionResult> Index()
        {
            var zavodContext = _context.PKvitanciya.Include(p => p.Khojagi).Include(p => p.Partiya);
            return View(await zavodContext.ToListAsync());
        }

        // GET: PKvitanciyas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pKvitanciya = await _context.PKvitanciya
                .Include(p => p.Khojagi)
                .Include(p => p.Partiya)
                .FirstOrDefaultAsync(m => m.PKvitanciyaID == id);
            if (pKvitanciya == null)
            {
                return NotFound();
            }

            return View(pKvitanciya);
        }

        // GET: PKvitanciyas/Create
        public IActionResult Create()
        {
            ViewData["KhojagiID"] = new SelectList(_context.Khojagi, "KhojagiID", "KhojagiID");
            ViewData["PartiyaID"] = new SelectList(_context.Partiya, "PartiyaID", "PartiyaID");
            return View();
        }

        // POST: PKvitanciyas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PKvitanciyaID,NomerPK,Data,NomerNakl,KhojagiID,PartiyaID,FizVes,Zasor,Vlagn")] PKvitanciya pKvitanciya)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pKvitanciya);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhojagiID"] = new SelectList(_context.Khojagi, "KhojagiID", "KhojagiID", pKvitanciya.KhojagiID);
            ViewData["PartiyaID"] = new SelectList(_context.Partiya, "PartiyaID", "PartiyaID", pKvitanciya.PartiyaID);
            return View(pKvitanciya);
        }

        // GET: PKvitanciyas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pKvitanciya = await _context.PKvitanciya.FindAsync(id);
            if (pKvitanciya == null)
            {
                return NotFound();
            }
            ViewData["KhojagiID"] = new SelectList(_context.Khojagi, "KhojagiID", "KhojagiID", pKvitanciya.KhojagiID);
            ViewData["PartiyaID"] = new SelectList(_context.Partiya, "PartiyaID", "PartiyaID", pKvitanciya.PartiyaID);
            return View(pKvitanciya);
        }

        // POST: PKvitanciyas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PKvitanciyaID,NomerPK,Data,NomerNakl,KhojagiID,PartiyaID,FizVes,Zasor,Vlagn")] PKvitanciya pKvitanciya)
        {
            if (id != pKvitanciya.PKvitanciyaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pKvitanciya);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PKvitanciyaExists(pKvitanciya.PKvitanciyaID))
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
            ViewData["KhojagiID"] = new SelectList(_context.Khojagi, "KhojagiID", "KhojagiID", pKvitanciya.KhojagiID);
            ViewData["PartiyaID"] = new SelectList(_context.Partiya, "PartiyaID", "PartiyaID", pKvitanciya.PartiyaID);
            return View(pKvitanciya);
        }

        // GET: PKvitanciyas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pKvitanciya = await _context.PKvitanciya
                .Include(p => p.Khojagi)
                .Include(p => p.Partiya)
                .FirstOrDefaultAsync(m => m.PKvitanciyaID == id);
            if (pKvitanciya == null)
            {
                return NotFound();
            }

            return View(pKvitanciya);
        }

        // POST: PKvitanciyas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pKvitanciya = await _context.PKvitanciya.FindAsync(id);
            _context.PKvitanciya.Remove(pKvitanciya);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PKvitanciyaExists(int id)
        {
            return _context.PKvitanciya.Any(e => e.PKvitanciyaID == id);
        }
    }
}
