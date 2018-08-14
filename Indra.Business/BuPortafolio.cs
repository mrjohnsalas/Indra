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
                myObject.NumPortafolio = GetId(systemDate.Year, systemDate.Month);
                myObject.CreateDate = systemDate;
                myObject.EditDate = systemDate;
                myObject.EstadoId = (int) EstadoType.EnEjecucion;
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
                var systemDate = DateTime.Now;
                myObject.EditDate = systemDate;
                //PROGRAMAS
                var buPrograma = new BuPrograma();
                var buPortafolioDetallePrograma = new BuPortafolioDetallePrograma();
                buPortafolioDetallePrograma.DeleteByPortafolioId(myObject.Id);
                if (myObject.Programas != null && !myObject.Programas.Count().Equals(0))
                    foreach (var programa in myObject.Programas)
                    {
                        programa.Portafolio = myObject;
                        programa.Programa = buPrograma.GetById(programa.ProgramaId);
                    }

                //PROYECTOS
                var buProyecto = new BuProyecto();
                var buPortafolioDetalleProyecto = new BuPortafolioDetalleProyecto();
                buPortafolioDetalleProyecto.DeleteByPortafolioId(myObject.Id);
                if (myObject.Proyectos != null && !myObject.Proyectos.Count().Equals(0))
                    foreach (var proyecto in myObject.Proyectos)
                    {
                        proyecto.Portafolio = myObject;
                        proyecto.Proyecto = buProyecto.GetById(proyecto.ProyectoId);
                    }

                _repository.Update(myObject);
                _unitOfWork.Commit();
                ////PROGRAMAS
                //var buPortafolioDetallePrograma = new BuPortafolioDetallePrograma();
                //buPortafolioDetallePrograma.DeleteByPortafolioId(myObject.Id);
                //if (myObject.Programas != null && !myObject.Programas.Count().Equals(0))
                //    foreach (var programa in myObject.Programas)
                //        buPortafolioDetallePrograma.Add(programa);
                ////PROYECTOS
                //var buPortafolioDetalleProyecto = new BuPortafolioDetalleProyecto();
                //buPortafolioDetalleProyecto.DeleteByPortafolioId(myObject.Id);
                //if (myObject.Proyectos != null && !myObject.Proyectos.Count().Equals(0))
                //    foreach (var proyecto in myObject.Proyectos)
                //        buPortafolioDetalleProyecto.Add(proyecto);
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