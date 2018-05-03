﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuCategoriaComponente
    {
        private readonly ICategoriaComponenteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuCategoriaComponente()
        {
            var db = new DbFactory();
            _repository = new CategoriaComponenteRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<CategoriaComponente> GetAll() => _repository.GetAll();

        public IEnumerable<CategoriaComponente> GetMany(Expression<Func<CategoriaComponente, bool>> where) => _repository.GetMany(where);

        public CategoriaComponente GetById(int id) => _repository.GetById(id);

        public CategoriaComponente Get(Expression<Func<CategoriaComponente, bool>> where) => _repository.Get(where);

        public void Add(CategoriaComponente myObject)
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

        public void Update(CategoriaComponente myObject)
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