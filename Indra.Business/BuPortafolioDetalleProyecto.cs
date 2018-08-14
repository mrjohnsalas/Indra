using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuPortafolioDetalleProyecto
    {
        private readonly IPortafolioDetalleProyectoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuPortafolioDetalleProyecto()
        {
            var db = new DbFactory();
            _repository = new PortafolioDetalleProyectoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<PortafolioDetalleProyecto> GetAll() => _repository.GetAll();

        public IEnumerable<PortafolioDetalleProyecto> GetMany(Expression<Func<PortafolioDetalleProyecto, bool>> where) => _repository.GetMany(where);

        public PortafolioDetalleProyecto GetById(int id) => _repository.GetById(id);

        public PortafolioDetalleProyecto Get(Expression<Func<PortafolioDetalleProyecto, bool>> where) => _repository.Get(where);

        public void Add(PortafolioDetalleProyecto myObject)
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

        public void Update(PortafolioDetalleProyecto myObject)
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
