using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XKnows.Data;
using XKnows.Models;

namespace XKnows.Controllers
{
    public class ShareController : Controller
    {
        private readonly ShareContext _context;

        public ShareController(ShareContext context)
        {
            _context = context;
        }

        // GET: Share
        public async Task<IActionResult> Index()
        {
            return View(await _context.Share.ToListAsync());
        }

        // GET: Share/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var share = await _context.Share
                .FirstOrDefaultAsync(m => m.Id == id);
            if (share == null)
            {
                return NotFound();
            }

            return View(share);
        }

        // GET: Share/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Share/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Skill,Level,Points")] Share share)
        {
            if (ModelState.IsValid)
            {
                _context.Add(share);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(share);
        }

        // GET: Share/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var share = await _context.Share.FindAsync(id);
            if (share == null)
            {
                return NotFound();
            }
            return View(share);
        }

        // POST: Share/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Skill,Level,Points")] Share share)
        {
            if (id != share.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(share);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShareExists(share.Id))
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
            return View(share);
        }

        // GET: Share/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var share = await _context.Share
                .FirstOrDefaultAsync(m => m.Id == id);
            if (share == null)
            {
                return NotFound();
            }

            return View(share);
        }

        // POST: Share/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var share = await _context.Share.FindAsync(id);
            _context.Share.Remove(share);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShareExists(int id)
        {
            return _context.Share.Any(e => e.Id == id);
        }
    }
}
