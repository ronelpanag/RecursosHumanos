using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recursos_Humanos.Models.Colaboradores
{
    public class Cargo
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [DisplayName("Departamento")]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}
