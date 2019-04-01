using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Colaboradores
{
    public class Departamento
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CodigoDepartamento { get; set; }
        [Required]
        public string NombreDepartamento { get; set; }
    }
}
