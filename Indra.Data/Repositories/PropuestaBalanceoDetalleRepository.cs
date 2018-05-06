using Indra.Data.Infrastructure;
using Indra.Model.Models;

namespace Indra.Data.Repositories
{
    public class PropuestaBalanceoDetalleRepository : RepositoryBase<PropuestaBalanceoDetalle>, IPropuestaBalanceoDetalleRepository
    {
        public PropuestaBalanceoDetalleRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IPropuestaBalanceoDetalleRepository : IRepository<PropuestaBalanceoDetalle> { }
}