using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using peliculasweb.Data;
using peliculasweb.Models;

namespace peliculasweb.Controllers
{
    public class PeliculasActoresController : Controller
    {
        private readonly AppDbContext _context;

        public PeliculasActoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PeliculasActores
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PeliculaActores.Include(p => p.Actor).Include(p => p.Pelicula);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PeliculasActores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaActor = await _context.PeliculaActores
                .Include(p => p.Actor)
                .Include(p => p.Pelicula)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (peliculaActor == null)
            {
                return NotFound();
            }

            return View(peliculaActor);
        }

        // GET: PeliculasActores/Create
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.Actores, "Id", "Discriminator");
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id");
            return View();
        }

        // POST: PeliculasActores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PeliculaId,ActorId")] PeliculaActor peliculaActor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peliculaActor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorId"] = new SelectList(_context.Actores, "Id", "Discriminator", peliculaActor.ActorId);
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", peliculaActor.PeliculaId);
            return View(peliculaActor);
        }

        // GET: PeliculasActores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaActor = await _context.PeliculaActores.FindAsync(id);
            if (peliculaActor == null)
            {
                return NotFound();
            }
            ViewData["ActorId"] = new SelectList(_context.Actores, "Id", "Discriminator", peliculaActor.ActorId);
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", peliculaActor.PeliculaId);
            return View(peliculaActor);
        }

        // POST: PeliculasActores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PeliculaId,ActorId")] PeliculaActor peliculaActor)
        {
            if (id != peliculaActor.PeliculaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peliculaActor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaActorExists(peliculaActor.PeliculaId))
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
            ViewData["ActorId"] = new SelectList(_context.Actores, "Id", "Discriminator", peliculaActor.ActorId);
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", peliculaActor.PeliculaId);
            return View(peliculaActor);
        }

        // GET: PeliculasActores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaActor = await _context.PeliculaActores
                .Include(p => p.Actor)
                .Include(p => p.Pelicula)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (peliculaActor == null)
            {
                return NotFound();
            }

            return View(peliculaActor);
        }

        // POST: PeliculasActores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peliculaActor = await _context.PeliculaActores.FindAsync(id);
            if (peliculaActor != null)
            {
                _context.PeliculaActores.Remove(peliculaActor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaActorExists(int id)
        {
            return _context.PeliculaActores.Any(e => e.PeliculaId == id);
        }
    }
}
