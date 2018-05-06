using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuPropuestaBalanceoDetalle
    {
        private readonly IPropuestaBalanceoDetalleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuPropuestaBalanceoDetalle()
        {
            var db = new DbFactory();
            _repository = new PropuestaBalanceoDetalleRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<PropuestaBalanceoDetalle> GetAll() => _repository.GetAll();

        public IEnumerable<PropuestaBalanceoDetalle> GetMany(Expression<Func<PropuestaBalanceoDetalle, bool>> where) => _repository.GetMany(where);

        public PropuestaBalanceoDetalle GetById(int id) => _repository.GetById(id);

        public PropuestaBalanceoDetalle Get(Expression<Func<PropuestaBalanceoDetalle, bool>> where) => _repository.Get(where);

        public void Add(PropuestaBalanceoDetalle myObject)
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

        public void Update(PropuestaBalanceoDetalle myObject)
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