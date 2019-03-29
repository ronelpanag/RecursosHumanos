using Recursos_Humanos.Models.Colaboradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Procesos
{
    public class Vacacion
    {
        public int Id { get; set; }
        public Empleado Empleado { get; set; }
        public int CodigoEmpleado { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public int AnioCorrespondiente { get; set; }
        public bool Completa { get; set; }
        public string Comentarios { get; set; }
    }
}
