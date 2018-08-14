using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuPortafolioDetallePrograma
    {
        private readonly IPortafolioDetalleProgramaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuPortafolioDetallePrograma()
        {
            var db = new DbFactory();
            _repository = new PortafolioDetalleProgramaRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<PortafolioDetallePrograma> GetAll() => _repository.GetAll();

        public IEnumerable<PortafolioDetallePrograma> GetMany(Expression<Func<PortafolioDetallePrograma, bool>> where) => _repository.GetMany(where);

        public PortafolioDetallePrograma GetById(int id) => _repository.GetById(id);

        public PortafolioDetallePrograma Get(Expression<Func<PortafolioDetallePrograma, bool>> where) => _repository.Get(where);

        public void Add(PortafolioDetallePrograma myObject)
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

        public void Update(PortafolioDetallePrograma myObject)
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

        public void DeleteByPortafolioId(int id)
        {
            try
            {
                _repository.Delete(x => x.PortafolioId.Equals(id));
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}