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
    public class ItemAuthorsController : Controller
    {
        private readonly MuseumManagementContext _context;

        public ItemAuthorsController(MuseumManagementContext context)
        {
            _context = context;
        }

        // GET: ItemAuthors
        public async Task<IActionResult> Index()
        {
            var museumManagementContext = _context.ItemAuthor.Include(i => i.Author).Include(i => i.Item);
            return View(await museumManagementContext.ToListAsync());
        }

        // GET: ItemAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemAuthor = await _context.ItemAuthor
                .Include(i => i.Author)
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.IdItemAuthor == id);
            if (itemAuthor == null)
            {
                return NotFound();
            }

            return View(itemAuthor);
        }

        // GET: ItemAuthors/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Author, "IdAuthor", "AuthorName");
            ViewData["ItemId"] = new SelectList(_context.Item, "IdItem", "ItemName");
            return View();
        }

        // POST: ItemAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdItemAuthor,ItemId,AuthorId")] ItemAuthor itemAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "IdAuthor", "AuthorName", itemAuthor.AuthorId);
            ViewData["ItemId"] = new SelectList(_context.Item, "IdItem", "ItemName", itemAuthor.ItemId);
            return View(itemAuthor);
        }

        // GET: ItemAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemAuthor = await _context.ItemAuthor.FindAsync(id);
            if (itemAuthor == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "IdAuthor", "AuthorName", itemAuthor.AuthorId);
            ViewData["ItemId"] = new SelectList(_context.Item, "IdItem", "ItemName", itemAuthor.ItemId);
            return View(itemAuthor);
        }

        // POST: ItemAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdItemAuthor,ItemId,AuthorId")] ItemAuthor itemAuthor)
        {
            if (id != itemAuthor.IdItemAuthor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemAuthorExists(itemAuthor.IdItemAuthor))
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
            ViewData["AuthorId"] = new SelectList(_context.Author, "IdAuthor", "AuthorName", itemAuthor.AuthorId);
            ViewData["ItemId"] = new SelectList(_context.Item, "IdItem", "ItemName", itemAuthor.ItemId);
            return View(itemAuthor);
        }

        // GET: ItemAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemAuthor = await _context.ItemAuthor
                .Include(i => i.Author)
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.IdItemAuthor == id);
            if (itemAuthor == null)
            {
                return NotFound();
            }

            return View(itemAuthor);
        }

        // POST: ItemAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemAuthor = await _context.ItemAuthor.FindAsync(id);
            _context.ItemAuthor.Remove(itemAuthor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemAuthorExists(int id)
        {
            return _context.ItemAuthor.Any(e => e.IdItemAuthor == id);
        }
    }
}
