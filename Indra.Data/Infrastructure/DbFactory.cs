using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indra.Data.Context;

namespace Indra.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        IndraContext dbContext;

        public IndraContext Init()
        {
            return dbContext ?? (dbContext = new IndraContext());
        }

        protected override void DisposeCore()
        {
            dbContext?.Dispose();
        }
    }
}
