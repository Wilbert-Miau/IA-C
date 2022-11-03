using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IACAST_WEB.Data;
using IACAST_WEB.Models;
using Microsoft.AspNetCore.Authorization;

namespace IACAST_WEB.Controllers
{
    
    public class EpisodesController : Controller
    {
        private readonly IACAST_WEBContext _context;

        public EpisodesController(IACAST_WEBContext context)
        {
            _context = context;
        }

        // GET: Episodes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Episode.ToListAsync());
        }

        // GET: Episodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Episode == null)
            {
                return NotFound();
            }

            var episode = await _context.Episode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (episode == null)
            {
                return NotFound();
            }

            return View(episode);
        }



        // GET: Episodes/Create
        [Authorize]
        public IActionResult Create()
        {

           ViewBag.guestBag= _context.Guest.Select(a => a.Name);
            ViewBag.hostBag = _context.Hosts.Select(a => a.Name);


            return View();
        }

        // POST: Episodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Name,Theme,Released,Invitado,Anfitrion,Youtube")] Episode episode)
        {
            if (ModelState.IsValid)
            {   
                _context.Add(episode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(episode);
        }

        // GET: Episodes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)

        {
            ViewBag.guestBag = _context.Guest.Select(a => a.Name);

            ViewBag.hostBag = _context.Hosts.Select(a => a.Name);
            if (id == null || _context.Episode == null)
            {
                return NotFound();
            }


            var episode = await _context.Episode.FindAsync(id);
            if (episode == null)
            {
                return NotFound();
            }
            return View(episode);
        }

        // POST: Episodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Theme,Released,Invitado,Anfitrion,Youtube")] Episode episode)
        {
            if (id != episode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(episode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpisodeExists(episode.Id))
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
            return View(episode);
        }

        // GET: Episodes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Episode == null)
            {
                return NotFound();
            }

            var episode = await _context.Episode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (episode == null)
            {
                return NotFound();
            }

            return View(episode);
        }

        // POST: Episodes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Episode == null)
            {
                return Problem("Entity set 'IACAST_WEBContext.Episode'  is null.");
            }
            var episode = await _context.Episode.FindAsync(id);
            if (episode != null)
            {
                _context.Episode.Remove(episode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpisodeExists(int id)
        {
          return _context.Episode.Any(e => e.Id == id);
        }
    }
}
