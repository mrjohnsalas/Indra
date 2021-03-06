﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indra.Data.Infrastructure;
using Indra.Model.Models;

namespace Indra.Data.Repositories
{
    public class SolicitudRecursoRepository : RepositoryBase<SolicitudRecurso>, ISolicitudRecursoRepository
    {
        public SolicitudRecursoRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface ISolicitudRecursoRepository : IRepository<SolicitudRecurso> { }
}