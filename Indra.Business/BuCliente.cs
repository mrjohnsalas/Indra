using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuCliente
    {
        private readonly IClienteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuCliente()
        {
            var db = new DbFactory();
            _repository = new ClienteRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Cliente> GetAll() => _repository.GetAll();

        public IEnumerable<Cliente> GetMany(Expression<Func<Cliente, bool>> where) => _repository.GetMany(where);

        public Cliente GetById(int id) => _repository.GetById(id);

        public Cliente Get(Expression<Func<Cliente, bool>> where) => _repository.Get(where);

        public void Add(Cliente myObject)
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

        public void Update(Cliente myObject)
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