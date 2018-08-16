using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Proyecto> GetAllAvailable()
        {
            var portafolioDetalles = new BuPortafolioDetalleProyecto().GetAll();
            var proyectoIdList = (portafolioDetalles != null && !portafolioDetalles.Count().Equals(0))
                ? portafolioDetalles.Select(x => x.ProyectoId).ToList()
                : new List<int>();

            var programaDetalles = new BuProgramaDetalle().GetAll();
            var proyectoIdList2 = (programaDetalles != null && !programaDetalles.Count().Equals(0))
                ? programaDetalles.Select(x => x.ProyectoId).ToList()
                : new List<int>();

            foreach (var id in proyectoIdList2)
                if (!proyectoIdList.Contains(id))
                    proyectoIdList.Add(id);

            var proyectos = (portafolioDetalles == null || portafolioDetalles.Count().Equals(0))
                ? GetMany(x => x.EstadoId.Equals((int)EstadoType.EnEjecucion))
                : GetMany(x => x.EstadoId.Equals((int)EstadoType.EnEjecucion) && !proyectoIdList.Contains(x.Id));
            return proyectos;
        }

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