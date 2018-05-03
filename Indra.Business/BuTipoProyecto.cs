using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuTipoProyecto
    {
        private readonly ITipoProyectoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuTipoProyecto()
        {
            var db = new DbFactory();
            _repository = new TipoProyectoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<TipoProyecto> GetAll() => _repository.GetAll();

        public IEnumerable<TipoProyecto> GetMany(Expression<Func<TipoProyecto, bool>> where) => _repository.GetMany(where);

        public TipoProyecto GetById(int id) => _repository.GetById(id);

        public TipoProyecto Get(Expression<Func<TipoProyecto, bool>> where) => _repository.Get(where);

        public void Add(TipoProyecto myObject)
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

        public void Update(TipoProyecto myObject)
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