using Indra.Data.Infrastructure;
using Indra.Model.Models;

namespace Indra.Data.Repositories
{
    public class PropuestaBalanceoRepository : RepositoryBase<PropuestaBalanceo>, IPropuestaBalanceoRepository
    {
        public PropuestaBalanceoRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IPropuestaBalanceoRepository : IRepository<PropuestaBalanceo> { }
}