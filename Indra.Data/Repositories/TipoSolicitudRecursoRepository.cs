
using Indra.Data.Infrastructure;
using Indra.Model.Models;

namespace Indra.Data.Repositories
{
    public class TipoSolicitudRecursoRepository : RepositoryBase<TipoSolicitudRecurso>, ITipoSolicitudRecursoRepository
    {
        public TipoSolicitudRecursoRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface ITipoSolicitudRecursoRepository : IRepository<TipoSolicitudRecurso> { }
}
