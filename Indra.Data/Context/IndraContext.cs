using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indra.Model.Models;

namespace Indra.Data.Context
{
    public class IndraContext : DbContext
    {
        public IndraContext() : base("name=IndraContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new SeedData());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual void Commit() => SaveChanges();

        public DbSet<CategoriaComponente> CategoriaComponentes { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<CriterioEvaluacion> CriterioEvaluaciones { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<EstadoAprobacion> EstadoAprobaciones { get; set; }

        public DbSet<Patrocinador> Patrocinadores { get; set; }

        public DbSet<Portafolio> Portafolios { get; set; }

        public DbSet<Prioridad> Prioridades { get; set; }

        public DbSet<Programa> Programas { get; set; }

        public DbSet<Proyecto> Proyectos { get; set; }

        public DbSet<Recurso> Recursos { get; set; }

        public DbSet<TipoDocumentoIdentidad> TipoDocumentoIdentidades { get; set; }

        public DbSet<TipoProyecto> TipoProyectos { get; set; }

        public DbSet<Trabajador> Trabajadores { get; set; }

        public DbSet<SolicitudRecurso> SolicitudRecursos { get; set; }

        public DbSet<SolicitudRecursoDetalle> SolicitudRecursoDetalles { get; set; }

        public DbSet<Almacen> Almacenes { get; set; }

        public DbSet<AlmacenRecurso> AlmacenRecursos { get; set; }

        public DbSet<PropuestaBalanceo> PropuestaBalanceos { get; set; }

        public DbSet<PropuestaBalanceoDetalle> PropuestaBalanceoDetalles { get; set; }
    }
}