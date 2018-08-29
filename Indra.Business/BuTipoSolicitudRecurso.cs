using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuTipoSolicitudRecurso
    {
        private readonly ITipoSolicitudRecursoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuTipoSolicitudRecurso()
        {
            var db = new DbFactory();
            _repository = new TipoSolicitudRecursoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<TipoSolicitudRecurso> GetAll() => _repository.GetAll();

        public IEnumerable<TipoSolicitudRecurso> GetMany(Expression<Func<TipoSolicitudRecurso, bool>> where) => _repository.GetMany(where);

        public TipoSolicitudRecurso GetById(int id) => _repository.GetById(id);

        public TipoSolicitudRecurso Get(Expression<Func<TipoSolicitudRecurso, bool>> where) => _repository.Get(where);

        public void Add(TipoSolicitudRecurso myObject)
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

        public void Update(TipoSolicitudRecurso myObject)
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
