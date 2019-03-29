using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recursos_Humanos.Models.Colaboradores;
using Recursos_Humanos.Models.Procesos;

namespace Recursos_Humanos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<Vacacion> Vacaciones { get; set; }
        public DbSet<Licencia> Licencias { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Salida> Salidas { get; set; }
    }
}
