using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuPatrocinador
    {
        private readonly IPatrocinadorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuPatrocinador()
        {
            var db = new DbFactory();
            _repository = new PatrocinadorRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Patrocinador> GetAll() => _repository.GetAll();

        public IEnumerable<Patrocinador> GetMany(Expression<Func<Patrocinador, bool>> where) => _repository.GetMany(where);

        public Patrocinador GetById(int id) => _repository.GetById(id);

        public Patrocinador Get(Expression<Func<Patrocinador, bool>> where) => _repository.Get(where);

        public void Add(Patrocinador myObject)
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

        public void Update(Patrocinador myObject)
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