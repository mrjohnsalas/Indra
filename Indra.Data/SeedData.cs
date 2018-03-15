using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indra.Data.Context;
using Indra.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Indra.Data
{
    public class SeedData : DropCreateDatabaseIfModelChanges<IndraContext>
    {
        protected override void Seed(IndraContext context)
        {
            var db = new ApplicationDbContext();
        }
    }
}
