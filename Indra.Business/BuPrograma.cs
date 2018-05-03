using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuPrograma
    {
        private readonly IProgramaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuPrograma()
        {
            var db = new DbFactory();
            _repository = new ProgramaRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Programa> GetAll() => _repository.GetAll();

        public IEnumerable<Programa> GetMany(Expression<Func<Programa, bool>> where) => _repository.GetMany(where);

        public Programa GetById(int id) => _repository.GetById(id);

        public Programa Get(Expression<Func<Programa, bool>> where) => _repository.Get(where);

        public void Add(Programa myObject)
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

        public void Update(Programa myObject)
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