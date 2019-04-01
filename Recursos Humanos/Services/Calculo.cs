using Recursos_Humanos.Data;
using Recursos_Humanos.Models.Colaboradores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Services
{
    public class Calculo : ICalculo
    {
        protected DataTable DataTable;
        private readonly ApplicationDbContext _context;

        public IList<Empleado> Empleados()
        {
            //var emp = from e in Empleado select e;
            return null;
        }
        public double NominaTotal()
        {
            return 0;
        }
    }
}
