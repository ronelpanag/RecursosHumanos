using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Cod. Departamento")]
        public string CodigoDepartamento { get; set; }
        [Required]
        [DisplayName("Departamento")]
        public string NombreDepartamento { get; set; }
    }
}
