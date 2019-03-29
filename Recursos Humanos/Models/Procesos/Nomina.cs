using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Procesos
{
    public class Nomina
    {
        public int Id { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public double MontoTotal { get; set; }
    }
}
