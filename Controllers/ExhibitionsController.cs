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
    public class ExhibitionsController : Controller
    {
        private readonly MuseumManagementContext _context;

        public ExhibitionsController(MuseumManagementContext context)
        {
            _context = context;
        }

        // GET: Exhibitions
        public async Task<IActionResult> Index()
        {
            var museumManagementContext = _context.Exhibition.Include(e => e.Museum);
            return View(await museumManagementContext.ToListAsync());
        }

        // GET: Exhibitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibition
                .Include(e => e.Museum)
                .FirstOrDefaultAsync(m => m.IdExhibition == id);
            if (exhibition == null)
            {
                return NotFound();
            }

            return View(exhibition);
        }

        // GET: Exhibitions/Create
        public IActionResult Create()
        {
            ViewData["MuseumId"] = new SelectList(_context.Set<Museum>(), "IdMuseum", "MuseumName");
            return View();
        }

        // POST: Exhibitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExhibition,ExhibitionName,MuseumId")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exhibition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MuseumId"] = new SelectList(_context.Set<Museum>(), "IdMuseum", "MuseumName", exhibition.MuseumId);
            return View(exhibition);
        }

        // GET: Exhibitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibition.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }
            ViewData["MuseumId"] = new SelectList(_context.Set<Museum>(), "IdMuseum", "MuseumName", exhibition.MuseumId);
            return View(exhibition);
        }

        // POST: Exhibitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExhibition,ExhibitionName,MuseumId")] Exhibition exhibition)
        {
            if (id != exhibition.IdExhibition)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhibition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitionExists(exhibition.IdExhibition))
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
            ViewData["MuseumId"] = new SelectList(_context.Set<Museum>(), "IdMuseum", "MuseumName", exhibition.MuseumId);
            return View(exhibition);
        }

        // GET: Exhibitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibition = await _context.Exhibition
                .Include(e => e.Museum)
                .FirstOrDefaultAsync(m => m.IdExhibition == id);
            if (exhibition == null)
            {
                return NotFound();
            }

            return View(exhibition);
        }

        // POST: Exhibitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibition = await _context.Exhibition.FindAsync(id);
            _context.Exhibition.Remove(exhibition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExhibitionExists(int id)
        {
            return _context.Exhibition.Any(e => e.IdExhibition == id);
        }
    }
}
