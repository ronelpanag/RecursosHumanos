using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Colaboradores
{

    public class Empleado
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        [DisplayName("Departamento")]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        [Required]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FerchaIngreso { get; set; }
        [Required]
        public double Salario { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
