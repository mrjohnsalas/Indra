using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuAlmacenRecurso
    {
        private readonly IAlmacenRecursoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuAlmacenRecurso()
        {
            var db = new DbFactory();
            _repository = new AlmacenRecursoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<AlmacenRecurso> GetAll() => _repository.GetAll();

        public IEnumerable<AlmacenRecurso> GetMany(Expression<Func<AlmacenRecurso, bool>> where) => _repository.GetMany(where);

        public AlmacenRecurso GetById(int id) => _repository.GetById(id);

        public AlmacenRecurso Get(Expression<Func<AlmacenRecurso, bool>> where) => _repository.Get(where);

        public void Add(AlmacenRecurso myObject)
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

        public void Update(AlmacenRecurso myObject)
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