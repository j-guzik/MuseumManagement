using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuseumManagement.Data;
using MuseumManagement.Models;

namespace MuseumManagement.Controllers
{
    public class MuseumsController : Controller
    {
        private readonly MuseumManagementContext _context;

        public MuseumsController(MuseumManagementContext context)
        {
            _context = context;
        }

        // GET: Museums
        public async Task<IActionResult> Index()
        {
            var museumManagementContext = _context.Museum.Include(m => m.City);
            return View(await museumManagementContext.ToListAsync());
        }

        // GET: Museums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var museum = await _context.Museum
                .Include(m => m.City)
                .FirstOrDefaultAsync(m => m.IdMuseum == id);
            if (museum == null)
            {
                return NotFound();
            }

            return View(museum);
        }

        // GET: Museums/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.City, "IdCity", "CityName");
            return View();
        }

        // POST: Museums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMuseum,MuseumName,CityId")] Museum museum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(museum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "IdCity", "CityName", museum.CityId);
            return View(museum);
        }

        // GET: Museums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var museum = await _context.Museum.FindAsync(id);
            if (museum == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "IdCity", "CityName", museum.CityId);
            return View(museum);
        }

        // POST: Museums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMuseum,MuseumName,CityId")] Museum museum)
        {
            if (id != museum.IdMuseum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(museum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuseumExists(museum.IdMuseum))
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
            ViewData["CityId"] = new SelectList(_context.City, "IdCity", "CityName", museum.CityId);
            return View(museum);
        }

        // GET: Museums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var museum = await _context.Museum
                .Include(m => m.City)
                .FirstOrDefaultAsync(m => m.IdMuseum == id);
            if (museum == null)
            {
                return NotFound();
            }

            return View(museum);
        }

        // POST: Museums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var museum = await _context.Museum.FindAsync(id);
            _context.Museum.Remove(museum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuseumExists(int id)
        {
            return _context.Museum.Any(e => e.IdMuseum == id);
        }
    }
}
