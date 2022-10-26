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
    public class podcastEpisodeModelsController : Controller
    {
        private readonly Web_MVC_IA_CASTContext _context;

        public podcastEpisodeModelsController(Web_MVC_IA_CASTContext context)
        {
            _context = context;
        }

        // GET: podcastEpisodeModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.podcastEpisodeModel.ToListAsync());
        }

        // GET: podcastEpisodeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.podcastEpisodeModel == null)
            {
                return NotFound();
            }

            var podcastEpisodeModel = await _context.podcastEpisodeModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcastEpisodeModel == null)
            {
                return NotFound();
            }

            return View(podcastEpisodeModel);
        }

        // GET: podcastEpisodeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: podcastEpisodeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EpisodeNumber,Theme,DateRelease")] podcastEpisodeModel podcastEpisodeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcastEpisodeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(podcastEpisodeModel);
        }

        // GET: podcastEpisodeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.podcastEpisodeModel == null)
            {
                return NotFound();
            }

            var podcastEpisodeModel = await _context.podcastEpisodeModel.FindAsync(id);
            if (podcastEpisodeModel == null)
            {
                return NotFound();
            }
            return View(podcastEpisodeModel);
        }

        // POST: podcastEpisodeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EpisodeNumber,Theme,DateRelease")] podcastEpisodeModel podcastEpisodeModel)
        {
            if (id != podcastEpisodeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcastEpisodeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!podcastEpisodeModelExists(podcastEpisodeModel.Id))
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
            return View(podcastEpisodeModel);
        }

        // GET: podcastEpisodeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.podcastEpisodeModel == null)
            {
                return NotFound();
            }

            var podcastEpisodeModel = await _context.podcastEpisodeModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcastEpisodeModel == null)
            {
                return NotFound();
            }

            return View(podcastEpisodeModel);
        }

        // POST: podcastEpisodeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.podcastEpisodeModel == null)
            {
                return Problem("Entity set 'Web_MVC_IA_CASTContext.podcastEpisodeModel'  is null.");
            }
            var podcastEpisodeModel = await _context.podcastEpisodeModel.FindAsync(id);
            if (podcastEpisodeModel != null)
            {
                _context.podcastEpisodeModel.Remove(podcastEpisodeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool podcastEpisodeModelExists(int id)
        {
          return _context.podcastEpisodeModel.Any(e => e.Id == id);
        }
    }
}
