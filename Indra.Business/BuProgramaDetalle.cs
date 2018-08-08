using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuProgramaDetalle
    {
        private readonly IProgramaDetalleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuProgramaDetalle()
        {
            var db = new DbFactory();
            _repository = new ProgramaDetalleRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<ProgramaDetalle> GetAll() => _repository.GetAll();

        public IEnumerable<ProgramaDetalle> GetMany(Expression<Func<ProgramaDetalle, bool>> where) => _repository.GetMany(where);

        public ProgramaDetalle GetById(int id) => _repository.GetById(id);

        public ProgramaDetalle Get(Expression<Func<ProgramaDetalle, bool>> where) => _repository.Get(where);

        public void Add(ProgramaDetalle myObject)
        {
            try
            {
                _repository.Add(myObject);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ProgramaDetalle myObject)
        {
            try
            {
                _repository.Update(myObject);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var myObject = _repository.GetById(id);
                _repository.Delete(myObject);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}