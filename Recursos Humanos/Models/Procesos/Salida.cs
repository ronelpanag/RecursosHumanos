using Recursos_Humanos.Models.Colaboradores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Procesos
{
    public class Salida
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Empleado")]
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        [Required]
        [DisplayName("Tipo de Salida")]
        public string TipoSalida { get; set; }
        [Required]
        public string Motivo { get; set; }
        [Required]
        [DataType(DataType.Date)]

        [DisplayName("Fecha de Salida")]

        public DateTime FechaSalida { get; set; }
    }
}
