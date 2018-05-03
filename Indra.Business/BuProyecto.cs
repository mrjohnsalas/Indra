using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuProyecto
    {
        private readonly IProyectoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuProyecto()
        {
            var db = new DbFactory();
            _repository = new ProyectoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Proyecto> GetAll() => _repository.GetAll();

        public IEnumerable<Proyecto> GetMany(Expression<Func<Proyecto, bool>> where) => _repository.GetMany(where);

        public Proyecto GetById(int id) => _repository.GetById(id);

        public Proyecto Get(Expression<Func<Proyecto, bool>> where) => _repository.Get(where);

        public void Add(Proyecto myObject)
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

        public void Update(Proyecto myObject)
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