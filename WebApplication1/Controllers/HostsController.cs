using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HostsController : Controller
    {
        private readonly WebApplication1Context _context;

        public HostsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Hosts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Host.ToListAsync());
        }

        // GET: Hosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Host == null)
            {
                return NotFound();
            }

            var hosts = await _context.Host
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hosts == null)
            {
                return NotFound();
            }

            return View(hosts);
        }

        // GET: Hosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Hosts hosts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hosts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hosts);
        }

        // GET: Hosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Host == null)
            {
                return NotFound();
            }

            var hosts = await _context.Host.FindAsync(id);
            if (hosts == null)
            {
                return NotFound();
            }
            return View(hosts);
        }

        // POST: Hosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Hosts hosts)
        {
            if (id != hosts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hosts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostsExists(hosts.Id))
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
            return View(hosts);
        }

        // GET: Hosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Host == null)
            {
                return NotFound();
            }

            var hosts = await _context.Host
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hosts == null)
            {
                return NotFound();
            }

            return View(hosts);
        }

        // POST: Hosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Host == null)
            {
                return Problem("Entity set 'WebApplication1Context.Host'  is null.");
            }
            var hosts = await _context.Host.FindAsync(id);
            if (hosts != null)
            {
                _context.Host.Remove(hosts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostsExists(int id)
        {
          return _context.Host.Any(e => e.Id == id);
        }
    }
}
