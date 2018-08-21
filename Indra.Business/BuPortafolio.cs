using System;
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
            var propuestas = new BuPropuestaBalanceo().GetMany(x => x.EstadoId.Equals((int)Enums.EstadoType.Pendiente));
            var propuestaIdList = (propuestas != null && !propuestas.Count().Equals(0))
                ? propuestas.Select(x => x.PortafolioId).ToList()
                : new List<int>();

            var portafolios = (propuestas == null || propuestas.Count().Equals(0))
                ? GetMany(x => x.EstadoId.Equals((int) Enums.EstadoType.EnEjecucion))
                : GetMany(x => x.EstadoId.Equals((int) Enums.EstadoType.EnEjecucion) && !propuestaIdList.Contains(x.Id));
            return portafolios;
        }

        public IEnumerable<Portafolio> GetAll() => _repository.GetAll();

        public IEnumerable<Portafolio> GetMany(Expression<Func<Portafolio, bool>> where) => _repository.GetMany(where);

        public Portafolio GetById(int id) => _repository.GetById(id);

        private string GetId(int year, int month)
        {
            var portafolios = GetMany(x => x.CreateDate.Year.Equals(year) && x.CreateDate.Month.Equals(month));
            var num = (portafolios?.Count() ?? 0) + 1;
            return $"PO-{year}-{month:00}-{num:00000}";
        }

        public Portafolio Get(Expression<Func<Portafolio, bool>> where) => _repository.Get(where);

        public void Add(Portafolio myObject)
        {
            try
            {
                var systemDate = DateTime.Now;
                myObject.NumDocument = GetId(systemDate.Year, systemDate.Month);
                myObject.CreateDate = systemDate;
                myObject.EditDate = systemDate;
                myObject.EstadoId = (int) Enums.EstadoType.EnEjecucion;
                
                var proyectosIdList = myObject.Proyectos?.Select(x => x.Id).ToList() ?? new List<int>();
                myObject.Proyectos = null;

                var programasIdList = myObject.Programas?.Select(x => x.Id).ToList() ?? new List<int>();
                myObject.Programas = null;

                _repository.Add(myObject);
                _unitOfWork.Commit();

                var id = Get(x => x.NumDocument.Equals(myObject.NumDocument)).Id;

                //UPDATE PROYECTOS
                new BuProyecto().UpdatePortafolioId(id, proyectosIdList);

                //UPDATE PROGRAMAS
                new BuPrograma().UpdatePortafolioId(id, programasIdList);
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
                var systemDate = DateTime.Now;
                myObject.EditDate = systemDate;

                var proyectosIdList = myObject.Proyectos?.Select(x => x.Id).ToList() ?? new List<int>();
                myObject.Proyectos = null;

                var programasIdList = myObject.Programas?.Select(x => x.Id).ToList() ?? new List<int>();
                myObject.Programas = null;

                myObject.Documentos = new BuDocumento().GetMany(x => x.PortafolioId.HasValue && x.PortafolioId.Value.Equals(myObject.Id)).ToList();
                var documentosIdList = myObject.Documentos?.Select(x => x.Id).ToList();
                myObject.Documentos = null;

                _repository.Update(myObject);
                _unitOfWork.Commit();

                //PROYECTOS
                var buProyecto = new BuProyecto();
                buProyecto.ClearPortafolioId(myObject.Id);
                buProyecto.UpdatePortafolioId(myObject.Id, proyectosIdList);

                //PROGRAMAS
                var buPrograma = new BuPrograma();
                buPrograma.ClearPortafolioId(myObject.Id);
                buPrograma.UpdatePortafolioId(myObject.Id, programasIdList);

                //DOCUMENTOS
                var buDocumento = new BuDocumento();
                buDocumento.ClearPortafolioId(myObject.Id);
                buDocumento.UpdatePortafolioId(myObject.Id, documentosIdList);
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
                myObject.EstadoId = (int)Enums.EstadoType.Anulado;
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