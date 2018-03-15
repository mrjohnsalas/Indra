using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
