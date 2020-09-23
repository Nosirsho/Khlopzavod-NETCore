using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KlopZavod.Data;
using KlopZavod.Models;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace KlopZavod.Controllers
{
    public class KhojagisController : Controller
    {
        private readonly ZavodContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public KhojagisController(ZavodContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Khojagis
        public async Task<IActionResult> Index()
        {
            var zavodContext = _context.Khojagi.Include(k => k.Assoc).Include(k => k.Rayon);
            return View(await zavodContext.ToListAsync());
        }

        // GET: Khojagis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khojagi = await _context.Khojagi
                .Include(k => k.Assoc)
                .Include(k => k.Rayon)
                .FirstOrDefaultAsync(m => m.KhojagiID == id);
            if (khojagi == null)
            {
                return NotFound();
            }

            return View(khojagi);
        }

        // GET: Khojagis/Create
        public IActionResult Create()
        {
            ViewData["AssocID"] = new SelectList(_context.Assoc, "AssocID", "Name");
            ViewData["RayonID"] = new SelectList(_context.Set<Rayon>(), "RayonID", "Name");
            return View();
        }

        // POST: Khojagis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KhojagiID,Name,Director,RMA,Phone,Ga,AssocID,RayonID,ImageFile")] Khojagi khojagi)
        {
            if (ModelState.IsValid)
            {
                //Сохранение изобрадение в папку wwwroot/img/avatImg
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(khojagi.ImageFile.FileName);
                string extension = Path.GetExtension(khojagi.ImageFile.FileName);
                khojagi.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff")+extension;
                string path = Path.Combine(wwwRootPath + "/img/avatImg/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create)) {
                    await khojagi.ImageFile.CopyToAsync(fileStream);
                }

                // Запись в БД
                    _context.Add(khojagi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssocID"] = new SelectList(_context.Assoc, "AssocID", "AssocID", khojagi.AssocID);
            ViewData["RayonID"] = new SelectList(_context.Set<Rayon>(), "RayonID", "RayonID", khojagi.RayonID);
            return View(khojagi);
        }

        // GET: Khojagis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khojagi = await _context.Khojagi.FindAsync(id);
            if (khojagi == null)
            {
                return NotFound();
            }
            ViewData["AssocID"] = new SelectList(_context.Assoc, "AssocID", "Name", khojagi.AssocID);
            ViewData["RayonID"] = new SelectList(_context.Set<Rayon>(), "RayonID", "Name", khojagi.RayonID);
            return View(khojagi);
        }

        // POST: Khojagis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KhojagiID,Name,Director,RMA,Phone,Ga,AssocID,RayonID,ImageFile")] Khojagi khojagi)
        {
            if (id != khojagi.KhojagiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                                      

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(khojagi.ImageFile.FileName); // Возвращает имя файла без расширения пути к файлу,
                    string extension = Path.GetExtension(khojagi.ImageFile.FileName); // Возвращает расширение (включая точку ".") Указанной строки пути.
                    khojagi.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/img/avatImg/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await khojagi.ImageFile.CopyToAsync(fileStream);
                    }


                    _context.Update(khojagi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhojagiExists(khojagi.KhojagiID))
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
            ViewData["AssocID"] = new SelectList(_context.Assoc, "AssocID", "AssocID", khojagi.AssocID);
            ViewData["RayonID"] = new SelectList(_context.Set<Rayon>(), "RayonID", "RayonID", khojagi.RayonID);
            return View(khojagi);
        }

        // GET: Khojagis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khojagi = await _context.Khojagi
                .Include(k => k.Assoc)
                .Include(k => k.Rayon)
                .FirstOrDefaultAsync(m => m.KhojagiID == id);
            if (khojagi == null)
            {
                return NotFound();
            }

            return View(khojagi);
        }

        // POST: Khojagis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khojagi = await _context.Khojagi.FindAsync(id);

            //Удалить изображение из wwwroot/img/avatImg
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "img/avatImg", khojagi.ImageName);

            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //Удалить запись
            _context.Khojagi.Remove(khojagi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhojagiExists(int id)
        {
            return _context.Khojagi.Any(e => e.KhojagiID == id);
        }
    }
}
