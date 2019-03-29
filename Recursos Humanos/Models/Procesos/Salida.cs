using Recursos_Humanos.Models.Colaboradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Procesos
{
    public class Salida
    {
        public int Id { get; set; }
        public Empleado Empleado { get; set; }
        public int CodigoEmpleado { get; set; }
        public string TipoSalida { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}
