using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuTrabajador
    {
        private readonly ITrabajadorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuTrabajador()
        {
            var db = new DbFactory();
            _repository = new TrabajadorRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Trabajador> GetAll() => _repository.GetAll();

        public IEnumerable<Trabajador> GetMany(Expression<Func<Trabajador, bool>> where) => _repository.GetMany(where);

        public Trabajador GetById(int id) => _repository.GetById(id);

        public Trabajador Get(Expression<Func<Trabajador, bool>> where) => _repository.Get(where);

        public void Add(Trabajador myObject)
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

        public void Update(Trabajador myObject)
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