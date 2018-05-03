using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuEstado
    {
        private readonly IEstadoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuEstado()
        {
            var db = new DbFactory();
            _repository = new EstadoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Estado> GetAll() => _repository.GetAll();

        public IEnumerable<Estado> GetMany(Expression<Func<Estado, bool>> where) => _repository.GetMany(where);

        public Estado GetById(int id) => _repository.GetById(id);

        public Estado Get(Expression<Func<Estado, bool>> where) => _repository.Get(where);

        public void Add(Estado myObject)
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

        public void Update(Estado myObject)
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