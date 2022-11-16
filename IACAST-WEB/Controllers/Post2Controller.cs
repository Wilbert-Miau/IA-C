using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IACAST_WEB.Data;
using IACAST_WEB.Models;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography.X509Certificates;

namespace IACAST_WEB.Controllers
{
    public class Post2Controller : Controller
    {
        private readonly IACAST_WEBContext _context;
        private IWebHostEnvironment _hostEnviroment;

        public Post2Controller(IACAST_WEBContext context, IWebHostEnvironment hostEnviroment)
        {
            _context = context;
            _hostEnviroment = hostEnviroment;
        }

        // GET: Post2
        public async Task<IActionResult> Index()
        {
              return View(await _context.Post2.ToListAsync());
        }

        // GET: Post2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Post2 == null)
            {
                return NotFound();
            }

            var post2 = await _context.Post2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post2 == null)
            {
                return NotFound();
            }

            return View(post2);
        }

        // GET: Post2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Author,Content,Created,Imagen")] Post2 post2)
        {

            if (ModelState.IsValid)
            {
                if (post2.Imagen != null)
                { 
                    string wwwrothPath = _hostEnviroment.WebRootPath;
                    
                   string fileName = Path.GetFileNameWithoutExtension(post2.Imagen.FileName);
                    string extension = Path.GetExtension(post2.Imagen.FileName);
                    post2.imagenName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(@"wwwroot\Image\",fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await post2.Imagen.CopyToAsync(fileStream);
                    }
                }
               
                    _context.Add(post2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post2);
        }

        // GET: Post2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Post2 == null)
            {
                return NotFound();
            }

            var post2 = await _context.Post2.FindAsync(id);
            if (post2 == null)
            {
                return NotFound();
            }
            return View(post2);
        }

        // POST: Post2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Author,Content,Created")] Post2 post2)
        {
            if (id != post2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Post2Exists(post2.Id))
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
            return View(post2);
        }

        // GET: Post2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Post2 == null)
            {
                return NotFound();
            }

            var post2 = await _context.Post2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post2 == null)
            {
                return NotFound();
            }

            return View(post2);
        }

        // POST: Post2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Post2 == null)
            {
                return Problem("Entity set 'IACAST_WEBContext.Post2'  is null.");
            }
            var post2 = await _context.Post2.FindAsync(id);
            if (post2 != null)
            {
                _context.Post2.Remove(post2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Post2Exists(int id)
        {
          return _context.Post2.Any(e => e.Id == id);
        }
    }
}
