﻿using System;
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
    public class LocationsController : Controller
    {
        private readonly MuseumManagementContext _context;

        public LocationsController(MuseumManagementContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            var museumManagementContext = _context.Location.Include(l => l.Exhibition).Include(l => l.Item);
            return View(await museumManagementContext.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location
                .Include(l => l.Exhibition)
                .Include(l => l.Item)
                .FirstOrDefaultAsync(m => m.IdLocation == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            ViewData["ExhibitionId"] = new SelectList(_context.Exhibition, "IdExhibition", "ExhibitionName");
            ViewData["ItemId"] = new SelectList(_context.Item, "IdItem", "ItemName");
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLocation,ItemId,ExhibitionId,TimeFrom,TimeTo")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExhibitionId"] = new SelectList(_context.Exhibition, "IdExhibition", "ExhibitionName", location.ExhibitionId);
            ViewData["ItemId"] = new SelectList(_context.Item, "IdItem", "ItemName", location.ItemId);
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            ViewData["ExhibitionId"] = new SelectList(_context.Exhibition, "IdExhibition", "ExhibitionName", location.ExhibitionId);
            ViewData["ItemId"] = new SelectList(_context.Item, "IdItem", "ItemName", location.ItemId);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocation,ItemId,ExhibitionId,TimeFrom,TimeTo")] Location location)
        {
            if (id != location.IdLocation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.IdLocation))
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
            ViewData["ExhibitionId"] = new SelectList(_context.Exhibition, "IdExhibition", "ExhibitionName", location.ExhibitionId);
            ViewData["ItemId"] = new SelectList(_context.Item, "IdItem", "ItemName", location.ItemId);
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Location
                .Include(l => l.Exhibition)
                .Include(l => l.Item)
                .FirstOrDefaultAsync(m => m.IdLocation == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Location.FindAsync(id);
            _context.Location.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.IdLocation == id);
        }
    }
}
