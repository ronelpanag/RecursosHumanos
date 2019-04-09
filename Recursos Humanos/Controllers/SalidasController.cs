using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recursos_Humanos.Data;
using Recursos_Humanos.Models.Colaboradores;
using Recursos_Humanos.Models.Procesos;

namespace Recursos_Humanos.Controllers
{
    public class SalidasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalidasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Salidas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Salidas.Include(s => s.Empleado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Salidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salida = await _context.Salidas
                .Include(s => s.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salida == null)
            {
                return NotFound();
            }

            return View(salida);
        }

        // GET: Salidas/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombre", "Apellido");
            return View();
        }

        // POST: Salidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpleadoId,TipoSalida,Motivo,FechaSalida")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                var empleado = (from e in _context.Empleados where e.Id == salida.EmpleadoId select e);
                salida.Empleado = empleado.ToList<Empleado>().ElementAt(0);
                salida.Empleado.Estado = false;
                _context.Empleados.Update(salida.Empleado);
                _context.Add(salida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", salida.EmpleadoId);
            return View(salida);
        }

        // GET: Salidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salida = await _context.Salidas.FindAsync(id);
            if (salida == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", salida.EmpleadoId);
            return View(salida);
        }

        // POST: Salidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,TipoSalida,Motivo,FechaSalida")] Salida salida)
        {
            if (id != salida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalidaExists(salida.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", salida.EmpleadoId);
            return View(salida);
        }

        //// GET: Salidas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var salida = await _context.Salidas
        //        .Include(s => s.Empleado)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (salida == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(salida);
        //}

        //// POST: Salidas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var salida = await _context.Salidas.FindAsync(id);
        //    _context.Salidas.Remove(salida);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool SalidaExists(int id)
        {
            return _context.Salidas.Any(e => e.Id == id);
        }
    }
}
