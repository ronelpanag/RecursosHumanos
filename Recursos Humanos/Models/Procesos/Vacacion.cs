using Recursos_Humanos.Models.Colaboradores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Procesos
{
    public class Vacacion
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Empleado")]
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Desde { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Hasta { get; set; }
        [Required]
        public int AnioCorrespondiente { get; set; }
        [Required]
        public bool Completa { get; set; }
        [Required]
        public string Comentarios { get; set; }
    }
}
