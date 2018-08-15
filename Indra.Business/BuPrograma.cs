using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuPrograma
    {
        private readonly IProgramaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuPrograma()
        {
            var db = new DbFactory();
            _repository = new ProgramaRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Programa> GetAll() => _repository.GetAll();

        public IEnumerable<Programa> GetAllForPortafolio()
        {
            var portafolioDetalles = new BuPortafolioDetallePrograma().GetAll();
            var programaIdList = (portafolioDetalles != null && !portafolioDetalles.Count().Equals(0))
                ? portafolioDetalles.Select(x => x.ProgramaId).ToList()
                : new List<int>();

            var programas = (portafolioDetalles == null || portafolioDetalles.Count().Equals(0))
                ? GetMany(x => x.EstadoId.Equals((int) EstadoType.EnEjecucion))
                : GetMany(x => x.EstadoId.Equals((int) EstadoType.EnEjecucion) && !programaIdList.Contains(x.Id));
            return programas;
        }

        public IEnumerable<Programa> GetMany(Expression<Func<Programa, bool>> where) => _repository.GetMany(where);

        public Programa GetById(int id) => _repository.GetById(id);

        public Programa Get(Expression<Func<Programa, bool>> where) => _repository.Get(where);

        public void Add(Programa myObject)
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

        public void Update(Programa myObject)
        {
            try
            {
                _repository.Update(myObject);
                _unitOfWork.Commit();

                //PROYECTOS
                var buProgramaDetalle = new BuProgramaDetalle();
                buProgramaDetalle.DeleteByProgramaId(myObject.Id);
                if (myObject.Proyectos != null && !myObject.Proyectos.Count().Equals(0))
                    foreach (var proyecto in myObject.Proyectos)
                    {
                        proyecto.Programa = null;
                        buProgramaDetalle.Add(proyecto);
                    }
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
                myObject.EstadoId = (int)EstadoType.Anulado;
                _repository.Update(myObject);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}