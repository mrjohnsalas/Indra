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

        public DbSet<CriterioEvaluacion> CriterioEvaluaciones { get; set; }

        public DbSet<CategoriaComponente> CategoriaComponentes { get; set; }
    }
}