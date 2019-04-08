using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recursos_Humanos.Data;
using Recursos_Humanos.Models.Colaboradores;
using Recursos_Humanos.Models.Informes;

namespace Recursos_Humanos.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Empleados.Include(e => e.Cargo).Include(e => e.Departamento);
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.Cargo)
                .Include(e => e.Departamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Descripcion");
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "CodigoDepartamento");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Telefono,DepartamentoId,CargoId,FerchaIngreso,Salario,Estado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                //int id = 0;
                //if(_context.Empleados.Count() == 0) 
                //{
                //    id = 1;
                //}
                //else
                //{
                //    id = ((from e in _context.Empleados select e.Id).Last() + 1);
                //}

                //empleado.Id = id;
                empleado.Estado = true;
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Descripcion", empleado.CargoId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "CodigoDepartamento", empleado.DepartamentoId);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Descripcion", empleado.CargoId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "CodigoDepartamento", empleado.DepartamentoId);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Telefono,DepartamentoId,CargoId,FerchaIngreso,Salario,Estado")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
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
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Descripcion", empleado.CargoId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "CodigoDepartamento", empleado.DepartamentoId);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.Cargo)
                .Include(e => e.Departamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //    var empleado = await _context.Empleados.FindAsync(id);
            //    empleado.Estado = false;
            //    _context.Update(empleado);
            //    await _context.SaveChangesAsync();
            return RedirectToAction("Create", "Salidas", id);
        }

        public async Task<IActionResult> EmpleadoActivos()
        {
            var listado = (from e in _context.Empleados where e.Estado == true select e).ToListAsync();
            return View(await listado);
        }

        public async Task<IActionResult> EmpleadosInactivos()
        {
            var listado = (from e in _context.Empleados where e.Estado == false select e).ToListAsync();
            return View(await listado);
        }

        public JsonResult EstadisticasEmpleados()
        {
            DataTable dataTable = new DataTable();
            DataColumn dataColumn = new DataColumn("Mes", typeof(string));
            DataColumn dataColumn1 = new DataColumn("Empleados activos", typeof(int));
            DataColumn dataColumn2 = new DataColumn("Entradas", typeof(int));
            DataColumn dataColumn3 = new DataColumn("Salidas", typeof(int));
            dataTable.Columns.Add(dataColumn);
            dataTable.Columns.Add(dataColumn1);
            dataTable.Columns.Add(dataColumn2);
            dataTable.Columns.Add(dataColumn3);

            var data = new List<Estadisticas>();
            for(int x = 1; x <= 12; x++)
            {
                int total = (from e in _context.Empleados
                                 where e.FerchaIngreso.Year == DateTime.Today.Year && e.FerchaIngreso.Month < (x+1)
                                 select e
                             ).Count();
                int activos = (from e in _context.Empleados
                                    where e.Estado == true && e.FerchaIngreso.Month == x
                                    select e
                              ).Count();
                int inactivos = (from e in _context.Empleados
                                 join s in _context.Salidas on e.Id equals s.EmpleadoId
                                        where e.Estado == false && s.FechaSalida.Month == x
                                        select e
                                ).Count();

                switch (x)
                {
                    case 1:
                        data.Add(new Estadisticas("Enero", total, activos, inactivos));
                        break;
                    case 2:
                       data.Add(new Estadisticas("Febrero", total, activos, inactivos));
                        break;
                    case 3:
                       data.Add(new Estadisticas("Marzo", total, activos, inactivos));
                        break;
                    case 4:
                       data.Add(new Estadisticas("Abril", total, activos, inactivos));
                        break;
                    case 5:
                       data.Add(new Estadisticas("Mayo", total, activos, inactivos));
                        break;
                    case 6:
                       data.Add(new Estadisticas("Junio", total, activos, inactivos));
                        break;
                    case 7:
                       data.Add(new Estadisticas("Julio", total, activos, inactivos));
                        break;
                    case 8:
                       data.Add(new Estadisticas("Agosto", total, activos, inactivos));
                        break;
                    case 9:
                       data.Add(new Estadisticas("Septiembre", total, activos, inactivos));
                        break;
                    case 10:
                       data.Add(new Estadisticas("Octubre", total, activos, inactivos));
                        break;
                    case 11:
                       data.Add(new Estadisticas("Noviembre", total, activos, inactivos));
                        break;
                    case 12:
                       data.Add(new Estadisticas("Diciembre", total, activos, inactivos));
                        break;
                    default:
                        Console.WriteLine("Error en las estadisticas");
                        break;
                }
            }

            for (int x = 0; x < data.Count; x++)
            {
                var y = data.ElementAt(x);
                dataTable.Rows.Add(y.Mes, y.Total, y.Activos, y.Inactivos);
            }
            return Json(data);

        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
