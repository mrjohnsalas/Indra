using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indra.Data.Infrastructure;
using Indra.Model.Models;

namespace Indra.Data.Repositories
{
    public class DocumentoRepository : RepositoryBase<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IDocumentoRepository : IRepository<Documento> { }
}