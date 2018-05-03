using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuEstadoAprobacion
    {
        private readonly IEstadoAprobacionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuEstadoAprobacion()
        {
            var db = new DbFactory();
            _repository = new EstadoAprobacionRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<EstadoAprobacion> GetAll() => _repository.GetAll();

        public IEnumerable<EstadoAprobacion> GetMany(Expression<Func<EstadoAprobacion, bool>> where) => _repository.GetMany(where);

        public EstadoAprobacion GetById(int id) => _repository.GetById(id);

        public EstadoAprobacion Get(Expression<Func<EstadoAprobacion, bool>> where) => _repository.Get(where);

        public void Add(EstadoAprobacion myObject)
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

        public void Update(EstadoAprobacion myObject)
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
