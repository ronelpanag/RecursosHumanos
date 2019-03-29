using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Colaboradores
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Departamento Departamento { get; set; }
        public int CodigoDepartamento { get; set; }
    }
}
