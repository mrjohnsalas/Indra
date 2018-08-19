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
            return GetMany(x => !x.PortafolioId.HasValue && !x.ProgramaId.HasValue && x.EstadoId.Equals((int)EstadoType.EnEjecucion));
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

        public void ClearProgramaId(int programaId)
        {
            var proyectos = GetMany(x => x.ProgramaId.HasValue && x.ProgramaId.Value.Equals(programaId));
            foreach (var proyecto in proyectos)
            {
                proyecto.ProgramaId = null;
                Update(proyecto);
            }
        }

        public void UpdateProgramaId(int programaId, List<int> proyectosIdList)
        {
            foreach (var id in proyectosIdList)
            {
                var proyecto = GetById(id);
                proyecto.ProgramaId = programaId;
                Update(proyecto);
            }
        }

        public void ClearPortafolioId(int portafolioId)
        {
            var proyectos = GetMany(x => x.PortafolioId.HasValue && x.PortafolioId.Value.Equals(portafolioId));
            foreach (var proyecto in proyectos)
            {
                proyecto.PortafolioId = null;
                Update(proyecto);
            }
        }

        public void UpdatePortafolioId(int portafolioId, List<int> proyectosIdList)
        {
            foreach (var id in proyectosIdList)
            {
                var proyecto = GetById(id);
                proyecto.PortafolioId = portafolioId;
                Update(proyecto);
            }
        }

        public IEnumerable<Proyecto> GetProyectosFullByPortafolioIdOrProgramaId(int portafolioId, int programaId)
        {
            var id = portafolioId + programaId;

            var proyectos = !portafolioId.Equals(0) 
                ? GetMany(x => x.PortafolioId.HasValue && x.PortafolioId.Value.Equals(id)).ToList()
                : GetMany(x => x.ProgramaId.HasValue && x.ProgramaId.Value.Equals(id)).ToList();

            var buCliente = new BuCliente();
            var buPatrocinador = new BuPatrocinador();
            var buSolicitudRecurso = new BuSolicitudRecurso();
            var buSolicitudRecursoDetalle = new BuSolicitudRecursoDetalle();
            var buRecurso = new BuRecurso();
            var buAlmacenRecurso = new BuAlmacenRecurso();
            
            var prioridades = new BuPrioridad().GetAll();
            var estados = new BuEstado().GetAll();
            var estadoAprobaciones = new BuEstadoAprobacion().GetAll();
            var trabajadores = new BuTrabajador().GetAll();
            var tipoProyectos = new BuTipoProyecto().GetAll();

            foreach (var proyecto in proyectos)
            {
                proyecto.Cliente = buCliente.GetById(proyecto.ClienteId);
                proyecto.Patrocinador = buPatrocinador.GetById(proyecto.PatrocinadorId);

                proyecto.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(proyecto.PrioridadId));
                proyecto.Estado = estados.FirstOrDefault(x => x.Id.Equals(proyecto.EstadoId));
                proyecto.EstadoAprobacion = estadoAprobaciones.FirstOrDefault(x => x.Id.Equals(proyecto.EstadoAprobacionId));
                proyecto.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(proyecto.ResponsableId));
                proyecto.TipoProyecto = tipoProyectos.FirstOrDefault(x => x.Id.Equals(proyecto.TipoProyectoId));

                var solicitudes = buSolicitudRecurso.GetMany(x => x.ProyectoId.Equals(proyecto.Id) && x.EstadoId.Equals((int)EstadoType.Pendiente));
                if (solicitudes == null) continue;
                {
                    proyecto.SolicitudesRecurso = solicitudes.ToList();
                    foreach (var solicitud in proyecto.SolicitudesRecurso)
                    {
                        solicitud.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(solicitud.PrioridadId));
                        var detallesSolicitud = buSolicitudRecursoDetalle.GetMany(x => x.SolicitudRecursoId.Equals(solicitud.Id));
                        if (detallesSolicitud == null) continue;
                        {
                            solicitud.Recursos = detallesSolicitud.ToList();
                            foreach (var detalle in solicitud.Recursos)
                            {
                                detalle.Recurso = buRecurso.GetById(detalle.RecursoId);
                                detalle.QuantityAvailable = buAlmacenRecurso.Get(x => x.AlmacenId.Equals(1) && x.RecursoId.Equals(detalle.RecursoId)).StockAvailable;
                                detalle.QuantityToAssign = (detalle.QuantityAvailable > detalle.QuantityPending) ? detalle.QuantityPending : detalle.QuantityAvailable;
                            }
                        }
                    }
                }
            }

            return proyectos;
        }
    }
}