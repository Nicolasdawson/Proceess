using System;
using System.Collections.Generic;
using System.Text;
using Portafolio.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Portafolio.Datos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TipoFlujo> Tipoflujos { get; set; }

        public DbSet<UnidadInterna> UnidadInternas { get; set; }

        public DbSet<FlujoTarea> FlujoTareas { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
    }


}
