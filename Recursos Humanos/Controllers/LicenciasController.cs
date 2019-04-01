using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recursos_Humanos.Data;
using Recursos_Humanos.Models.Procesos;

namespace Recursos_Humanos.Controllers
{
    public class LicenciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LicenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Licencias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Licencias.Include(l => l.Empleado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Licencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licencia = await _context.Licencias
                .Include(l => l.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licencia == null)
            {
                return NotFound();
            }

            return View(licencia);
        }

        // GET: Licencias/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido");
            return View();
        }

        // POST: Licencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpleadoId,Desde,Hasta,Motivo,Comentarios")] Licencia licencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", licencia.EmpleadoId);
            return View(licencia);
        }

        // GET: Licencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licencia = await _context.Licencias.FindAsync(id);
            if (licencia == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", licencia.EmpleadoId);
            return View(licencia);
        }

        // POST: Licencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,Desde,Hasta,Motivo,Comentarios")] Licencia licencia)
        {
            if (id != licencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenciaExists(licencia.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", licencia.EmpleadoId);
            return View(licencia);
        }

        // GET: Licencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licencia = await _context.Licencias
                .Include(l => l.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licencia == null)
            {
                return NotFound();
            }

            return View(licencia);
        }

        // POST: Licencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licencia = await _context.Licencias.FindAsync(id);
            _context.Licencias.Remove(licencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenciaExists(int id)
        {
            return _context.Licencias.Any(e => e.Id == id);
        }
    }
}
