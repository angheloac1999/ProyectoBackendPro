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
    public class PeliculasTrabajadoresController : Controller
    {
        private readonly AppDbContext _context;

        public PeliculasTrabajadoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PeliculasTrabajadores
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PeliculaTrabajadores.Include(p => p.Pelicula).Include(p => p.Trabajador);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PeliculasTrabajadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaTrabajador = await _context.PeliculaTrabajadores
                .Include(p => p.Pelicula)
                .Include(p => p.Trabajador)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (peliculaTrabajador == null)
            {
                return NotFound();
            }

            return View(peliculaTrabajador);
        }

        // GET: PeliculasTrabajadores/Create
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id");
            ViewData["TrabajadorId"] = new SelectList(_context.Trabajadores, "Id", "Discriminator");
            return View();
        }

        // POST: PeliculasTrabajadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PeliculaId,TrabajadorId")] PeliculaTrabajador peliculaTrabajador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peliculaTrabajador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", peliculaTrabajador.PeliculaId);
            ViewData["TrabajadorId"] = new SelectList(_context.Trabajadores, "Id", "Discriminator", peliculaTrabajador.TrabajadorId);
            return View(peliculaTrabajador);
        }

        // GET: PeliculasTrabajadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaTrabajador = await _context.PeliculaTrabajadores.FindAsync(id);
            if (peliculaTrabajador == null)
            {
                return NotFound();
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", peliculaTrabajador.PeliculaId);
            ViewData["TrabajadorId"] = new SelectList(_context.Trabajadores, "Id", "Discriminator", peliculaTrabajador.TrabajadorId);
            return View(peliculaTrabajador);
        }

        // POST: PeliculasTrabajadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PeliculaId,TrabajadorId")] PeliculaTrabajador peliculaTrabajador)
        {
            if (id != peliculaTrabajador.PeliculaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peliculaTrabajador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaTrabajadorExists(peliculaTrabajador.PeliculaId))
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
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", peliculaTrabajador.PeliculaId);
            ViewData["TrabajadorId"] = new SelectList(_context.Trabajadores, "Id", "Discriminator", peliculaTrabajador.TrabajadorId);
            return View(peliculaTrabajador);
        }

        // GET: PeliculasTrabajadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peliculaTrabajador = await _context.PeliculaTrabajadores
                .Include(p => p.Pelicula)
                .Include(p => p.Trabajador)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (peliculaTrabajador == null)
            {
                return NotFound();
            }

            return View(peliculaTrabajador);
        }

        // POST: PeliculasTrabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peliculaTrabajador = await _context.PeliculaTrabajadores.FindAsync(id);
            if (peliculaTrabajador != null)
            {
                _context.PeliculaTrabajadores.Remove(peliculaTrabajador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaTrabajadorExists(int id)
        {
            return _context.PeliculaTrabajadores.Any(e => e.PeliculaId == id);
        }
    }
}
