using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Colaboradores
{
    public class Empleado
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public Departamento Departamento { get; set; }
        [Required]
        public int CodigoDepartamento { get; set; }
        [Required]
        public Cargo Cargo { get; set; }
        [Required]
        public int CodigoCargo { get; set; }
        [Required]
        public DateTime FerchaIngreso { get; set; }
        [Required]
        public double Salario { get; set; }
        [Required]
        [Range(0, 1)]
        public int Estado { get; set; }
    }
}
