using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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

        public IEnumerable<Programa> GetAllAvailable()
        {
            return GetMany(x => !x.PortafolioId.HasValue && x.EstadoId.Equals((int)Enums.EstadoType.EnEjecucion));
        }

        public IEnumerable<Programa> GetMany(Expression<Func<Programa, bool>> where) => _repository.GetMany(where);

        public Programa GetById(int id) => _repository.GetById(id);

        private string GetId(int year, int month)
        {
            var programas = GetMany(x => x.CreateDate.Year.Equals(year) && x.CreateDate.Month.Equals(month));
            var num = (programas?.Count() ?? 0) + 1;
            return $"PR-{year}-{month:00}-{num:00000}";
        }

        public Programa Get(Expression<Func<Programa, bool>> where) => _repository.Get(where);

        public void Add(Programa myObject)
        {
            try
            {
                var systemDate = DateTime.Now;
                myObject.NumDocument = GetId(systemDate.Year, systemDate.Month);
                myObject.CreateDate = systemDate;
                myObject.EditDate = systemDate;
                myObject.EstadoId = (int)Enums.EstadoType.EnEjecucion;

                var proyectosIdList = myObject.Proyectos.Select(x => x.Id).ToList();
                myObject.Proyectos = null;

                _repository.Add(myObject);
                _unitOfWork.Commit();

                //UPDATE PROYECTOS
                var id = Get(x => x.NumDocument.Equals(myObject.NumDocument)).Id;
                new BuProyecto().UpdateProgramaId(id, proyectosIdList);
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
                var systemDate = DateTime.Now;
                myObject.EditDate = systemDate;

                var proyectosIdList = myObject.Proyectos?.Select(x => x.Id).ToList() ?? new List<int>();
                myObject.Proyectos = null;

                _repository.Update(myObject);
                _unitOfWork.Commit();

                //PROYECTOS
                var buProyecto = new BuProyecto();
                buProyecto.ClearProgramaId(myObject.Id);
                buProyecto.UpdateProgramaId(myObject.Id, proyectosIdList);
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

        public void ClearPortafolioId(int portafolioId)
        {
            var buProyecto = new BuProyecto();
            var programas = GetMany(x => x.PortafolioId.HasValue && x.PortafolioId.Value.Equals(portafolioId));
            foreach (var programa in programas)
            {
                programa.PortafolioId = null;
                programa.Proyectos = buProyecto.GetMany(x => x.ProgramaId.HasValue && x.ProgramaId.Value.Equals(programa.Id)).ToList();
                Update(programa);
            }
        }

        public void UpdatePortafolioId(int portafolioId, List<int> programasIdList)
        {
            var buProyecto = new BuProyecto();
            foreach (var id in programasIdList)
            {
                var programa = GetById(id);
                programa.PortafolioId = portafolioId;
                programa.Proyectos = buProyecto.GetMany(x => x.ProgramaId.HasValue && x.ProgramaId.Value.Equals(programa.Id)).ToList();
                Update(programa);
            }
        }

        public IEnumerable<Programa> GetProgramasFullByPortafolioId(int portafolioId)
        {
            var programas = GetMany(x => x.PortafolioId.HasValue && x.PortafolioId.Value.Equals(portafolioId)).ToList();

            var prioridades = new BuPrioridad().GetAll();
            var estados = new BuEstado().GetAll();
            var trabajadores = new BuTrabajador().GetAll();

            foreach (var programa in programas)
            {
                programa.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(programa.PrioridadId));
                programa.Estado = estados.FirstOrDefault(x => x.Id.Equals(programa.EstadoId));
                programa.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(programa.ResponsableId));
            }

            return programas;
        }

    }
}