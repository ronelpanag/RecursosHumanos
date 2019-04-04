using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Procesos
{
    public class Nomina
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Año")]
        public int Anio { get; set; }
        [Required]
        public int Mes { get; set; }
        [Required]
        public int Dia { get; set; }
        [Required]
        public double MontoTotal { get; set; }
    }
}
