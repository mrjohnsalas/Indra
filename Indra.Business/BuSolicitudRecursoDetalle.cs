using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuSolicitudRecursoDetalle
    {
        private readonly ISolicitudRecursoDetalleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuSolicitudRecursoDetalle()
        {
            var db = new DbFactory();
            _repository = new SolicitudRecursoDetalleRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<SolicitudRecursoDetalle> GetAll() => _repository.GetAll();

        public IEnumerable<SolicitudRecursoDetalle> GetMany(Expression<Func<SolicitudRecursoDetalle, bool>> where) => _repository.GetMany(where);

        public SolicitudRecursoDetalle GetById(int id) => _repository.GetById(id);

        public SolicitudRecursoDetalle Get(Expression<Func<SolicitudRecursoDetalle, bool>> where) => _repository.Get(where);

        public void Add(SolicitudRecursoDetalle myObject)
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

        public void Update(SolicitudRecursoDetalle myObject)
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