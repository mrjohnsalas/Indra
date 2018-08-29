using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuTipoDuracion
    {
        private readonly IDuracionTareaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuTipoDuracion()
        {
            var db = new DbFactory();
            _repository = new TipoDuracionRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<TipoDuracion> GetAll() => _repository.GetAll();

        public IEnumerable<TipoDuracion> GetMany(Expression<Func<TipoDuracion, bool>> where) => _repository.GetMany(where);

        public TipoDuracion GetById(int id) => _repository.GetById(id);

        public TipoDuracion Get(Expression<Func<TipoDuracion, bool>> where) => _repository.Get(where);

        public void Add(TipoDuracion myObject)
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

        public void Update(TipoDuracion myObject)
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
