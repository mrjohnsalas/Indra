using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuTipoDocumentoIdentidad
    {
        private readonly ITipoDocumentoIdentidadRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuTipoDocumentoIdentidad()
        {
            var db = new DbFactory();
            _repository = new TipoDocumentoIdentidadRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<TipoDocumentoIdentidad> GetAll() => _repository.GetAll();

        public IEnumerable<TipoDocumentoIdentidad> GetMany(Expression<Func<TipoDocumentoIdentidad, bool>> where) => _repository.GetMany(where);

        public TipoDocumentoIdentidad GetById(int id) => _repository.GetById(id);

        public TipoDocumentoIdentidad Get(Expression<Func<TipoDocumentoIdentidad, bool>> where) => _repository.Get(where);

        public void Add(TipoDocumentoIdentidad myObject)
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

        public void Update(TipoDocumentoIdentidad myObject)
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