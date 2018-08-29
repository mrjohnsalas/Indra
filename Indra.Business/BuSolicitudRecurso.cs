using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuSolicitudRecurso
    {
        private readonly ISolicitudRecursoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuSolicitudRecurso()
        {
            var db = new DbFactory();
            _repository = new SolicitudRecursoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<SolicitudRecurso> GetAll() => _repository.GetAll();

        public IEnumerable<SolicitudRecurso> GetMany(Expression<Func<SolicitudRecurso, bool>> where) => _repository.GetMany(where);

        public SolicitudRecurso GetById(int id) => _repository.GetById(id);

        public SolicitudRecurso Get(Expression<Func<SolicitudRecurso, bool>> where) => _repository.Get(where);

        public void Add(SolicitudRecurso myObject)
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

        public void Update(SolicitudRecurso myObject)
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

        public IEnumerable<SolicitudRecurso> GetSolicitudesFullByProyectoId(int proyectoId)
        {
            var solicitudes = GetMany(x => x.ProyectoId.Equals(proyectoId)).ToList();

            var buSolicitudRecursoDetalle = new BuSolicitudRecursoDetalle();
            var buRecurso = new BuRecurso();
            var buAlmacenRecurso = new BuAlmacenRecurso();

            var prioridades = new BuPrioridad().GetAll();
            var estados = new BuEstado().GetAll();
            var trabajadores = new BuTrabajador().GetAll();

            foreach (var solicitud in solicitudes)
            {
                solicitud.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(solicitud.PrioridadId));
                solicitud.Estado = estados.FirstOrDefault(x => x.Id.Equals(solicitud.EstadoId));
                solicitud.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(solicitud.ResponsableId));

                solicitud.Recursos = buSolicitudRecursoDetalle.GetMany(x => x.SolicitudRecursoId.Equals(solicitud.Id)).ToList();
                foreach (var detalle in solicitud.Recursos)
                {
                    detalle.Recurso = buRecurso.GetById(detalle.RecursoId);
                    detalle.QuantityAvailable = buAlmacenRecurso
                        .Get(x => x.AlmacenId.Equals(1) && x.RecursoId.Equals(detalle.RecursoId))
                        .StockAvailable;
                    detalle.QuantityToAssign = (detalle.QuantityAvailable > detalle.QuantityPending)
                        ? detalle.QuantityPending
                        : detalle.QuantityAvailable;
                }
            }

            return solicitudes;
        }
    }
}