﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuPortafolio
    {
        private readonly IPortafolioRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuPortafolio()
        {
            var db = new DbFactory();
            _repository = new PortafolioRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Portafolio> GetAllForPropuesta()
        {
            var propuestas = new BuPropuestaBalanceo().GetMany(x => x.EstadoId.Equals((int)EstadoType.Pendiente));
            var propuestaIdList = (propuestas != null && !propuestas.Count().Equals(0))
                ? propuestas.Select(x => x.PortafolioId).ToList()
                : new List<int>();

            var portafolios = (propuestas == null || propuestas.Count().Equals(0))
                ? GetMany(x => x.EstadoId.Equals((int) EstadoType.EnEjecucion))
                : GetMany(x => x.EstadoId.Equals((int) EstadoType.EnEjecucion) && !propuestaIdList.Contains(x.Id));
            return portafolios;
        }

        public IEnumerable<Portafolio> GetAll() => _repository.GetAll();

        public IEnumerable<Portafolio> GetMany(Expression<Func<Portafolio, bool>> where) => _repository.GetMany(where);

        public Portafolio GetById(int id) => _repository.GetById(id);

        public Portafolio Get(Expression<Func<Portafolio, bool>> where) => _repository.Get(where);

        public void Add(Portafolio myObject)
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

        public void Update(Portafolio myObject)
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