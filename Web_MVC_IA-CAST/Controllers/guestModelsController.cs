using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_MVC_IA_CAST.Data;
using Web_MVC_IA_CAST.Models;

namespace Web_MVC_IA_CAST.Controllers
{
    public class guestModelsController : Controller
    {
        private readonly Web_MVC_IA_CASTContext _context;

        public guestModelsController(Web_MVC_IA_CASTContext context)
        {
            _context = context;
        }

        // GET: guestModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.guestModel.ToListAsync());
        }

        // GET: guestModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.guestModel == null)
            {
                return NotFound();
            }

            var guestModel = await _context.guestModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestModel == null)
            {
                return NotFound();
            }

            return View(guestModel);
        }

        // GET: guestModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: guestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] guestModel guestModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guestModel);
        }

        // GET: guestModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.guestModel == null)
            {
                return NotFound();
            }

            var guestModel = await _context.guestModel.FindAsync(id);
            if (guestModel == null)
            {
                return NotFound();
            }
            return View(guestModel);
        }

        // POST: guestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] guestModel guestModel)
        {
            if (id != guestModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!guestModelExists(guestModel.Id))
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
            return View(guestModel);
        }

        // GET: guestModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.guestModel == null)
            {
                return NotFound();
            }

            var guestModel = await _context.guestModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestModel == null)
            {
                return NotFound();
            }

            return View(guestModel);
        }

        // POST: guestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.guestModel == null)
            {
                return Problem("Entity set 'Web_MVC_IA_CASTContext.guestModel'  is null.");
            }
            var guestModel = await _context.guestModel.FindAsync(id);
            if (guestModel != null)
            {
                _context.guestModel.Remove(guestModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool guestModelExists(int id)
        {
          return _context.guestModel.Any(e => e.Id == id);
        }
    }
}
