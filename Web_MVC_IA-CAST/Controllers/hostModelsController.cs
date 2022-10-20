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
    public class hostModelsController : Controller
    {
        private readonly Web_MVC_IA_CASTContext _context;

        public hostModelsController(Web_MVC_IA_CASTContext context)
        {
            _context = context;
        }

        // GET: hostModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.hostModel.ToListAsync());
        }

        // GET: hostModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.hostModel == null)
            {
                return NotFound();
            }

            var hostModel = await _context.hostModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostModel == null)
            {
                return NotFound();
            }

            return View(hostModel);
        }

        // GET: hostModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: hostModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] hostModel hostModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hostModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hostModel);
        }

        // GET: hostModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.hostModel == null)
            {
                return NotFound();
            }

            var hostModel = await _context.hostModel.FindAsync(id);
            if (hostModel == null)
            {
                return NotFound();
            }
            return View(hostModel);
        }

        // POST: hostModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] hostModel hostModel)
        {
            if (id != hostModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hostModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hostModelExists(hostModel.Id))
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
            return View(hostModel);
        }

        // GET: hostModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.hostModel == null)
            {
                return NotFound();
            }

            var hostModel = await _context.hostModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostModel == null)
            {
                return NotFound();
            }

            return View(hostModel);
        }

        // POST: hostModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.hostModel == null)
            {
                return Problem("Entity set 'Web_MVC_IA_CASTContext.hostModel'  is null.");
            }
            var hostModel = await _context.hostModel.FindAsync(id);
            if (hostModel != null)
            {
                _context.hostModel.Remove(hostModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool hostModelExists(int id)
        {
          return _context.hostModel.Any(e => e.Id == id);
        }
    }
}
