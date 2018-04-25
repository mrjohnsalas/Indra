using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuCriterioEvaluacion
    {
        private readonly ICriterioEvaluacionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuCriterioEvaluacion()
        {
            var db = new DbFactory();
            _repository = new CriterioEvaluacionRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<CriterioEvaluacion> GetAll() => _repository.GetAll();

        public IEnumerable<CriterioEvaluacion> GetMany(Expression<Func<CriterioEvaluacion, bool>> where) => _repository.GetMany(where);

        public CriterioEvaluacion GetById(int id) => _repository.GetById(id);

        public CriterioEvaluacion Get(Expression<Func<CriterioEvaluacion, bool>> where) => _repository.Get(where);

        public void Add(CriterioEvaluacion myObject)
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

        public void Update(CriterioEvaluacion myObject)
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