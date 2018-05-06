using Indra.Data.Infrastructure;
using Indra.Model.Models;

namespace Indra.Data.Repositories
{
    public class AlmacenRepository : RepositoryBase<Almacen>, IAlmacenRepository
    {
        public AlmacenRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IAlmacenRepository : IRepository<Almacen> { }
}