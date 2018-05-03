using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuRecurso
    {
        private readonly IRecursoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuRecurso()
        {
            var db = new DbFactory();
            _repository = new RecursoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Recurso> GetAll() => _repository.GetAll();

        public IEnumerable<Recurso> GetMany(Expression<Func<Recurso, bool>> where) => _repository.GetMany(where);

        public Recurso GetById(int id) => _repository.GetById(id);

        public Recurso Get(Expression<Func<Recurso, bool>> where) => _repository.Get(where);

        public void Add(Recurso myObject)
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

        public void Update(Recurso myObject)
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