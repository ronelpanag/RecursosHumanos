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
    public class NominasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NominasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nominas
        public async Task<IActionResult> Index(int x)
        {
            
            var montos = from n in _context.Nominas select n.MontoTotal;
            double total = montos.Sum();
            ViewData["Nomina"] = total.ToString();
            return View(await _context.Nominas.ToListAsync());
        }

        // GET: Nominas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nomina == null)
            {
                return NotFound();
            }

            return View(nomina);
        }

        // GET: Nominas/Create
        public IActionResult Create()
        {
            Nomina nomina = new Nomina();
            var monto = (from e in _context.Empleados where e.Estado == true select e.Salario);
            nomina.MontoTotal = monto.Sum();
            return View(nomina);
        }

        // POST: Nominas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Anio,Mes,Dia,MontoTotal")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                var monto = (from e in _context.Empleados where e.Estado == true select e.Salario);
                nomina.MontoTotal = monto.Sum();
                _context.Add(nomina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nomina);
        }

        // GET: Nominas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas.FindAsync(id);
            if (nomina == null)
            {
                return NotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Anio,Mes,Dia,MontoTotal")] Nomina nomina)
        {
            if (id != nomina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nomina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NominaExists(nomina.Id))
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
            return View(nomina);
        }

        // GET: Nominas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nomina == null)
            {
                return NotFound();
            }

            return View(nomina);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nomina = await _context.Nominas.FindAsync(id);
            _context.Nominas.Remove(nomina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NominaExists(int id)
        {
            return _context.Nominas.Any(e => e.Id == id);
        }
    }
}
