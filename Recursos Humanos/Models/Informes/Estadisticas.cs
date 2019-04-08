using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Informes
{
    public class Estadisticas
    {
        public string Mes { get; set; }
        public int Total { get; set; }
        public int Activos { get; set; }
        public int Inactivos { get; set; }

        public Estadisticas(string mes, int total, int activos, int inactivos)
        {
            Mes = mes;
            Total = total;
            Activos = activos;
            Inactivos = inactivos;
        }
    }
}
