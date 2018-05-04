using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuAlmacen
    {
        private readonly IAlmacenRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuAlmacen()
        {
            var db = new DbFactory();
            _repository = new AlmacenRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Almacen> GetAll() => _repository.GetAll();

        public IEnumerable<Almacen> GetMany(Expression<Func<Almacen, bool>> where) => _repository.GetMany(where);

        public Almacen GetById(int id) => _repository.GetById(id);

        public Almacen Get(Expression<Func<Almacen, bool>> where) => _repository.Get(where);

        public void Add(Almacen myObject)
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

        public void Update(Almacen myObject)
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