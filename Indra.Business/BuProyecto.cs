using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;
using Decimal = System.Decimal;

namespace Indra.Business
{
    public class BuProyecto
    {
        private readonly IProyectoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _verde = "#1ab394";
        private readonly string _verdeClaro = "#79d2c0";
        private readonly string _plomo = "#bababa";

        public BuProyecto()
        {
            var db = new DbFactory();
            _repository = new ProyectoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Proyecto> GetAll() => _repository.GetAll();

        public IEnumerable<Proyecto> GetAllAvailable()
        {
            return GetMany(x => !x.PortafolioId.HasValue && !x.ProgramaId.HasValue && x.EstadoId.Equals((int)Enums.EstadoType.EnEjecucion));
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

        public Proyecto GetFullById(int id, bool loadStatisticalData)
        {
            var proyecto = GetById(id);

            if (proyecto == null)
                return null;

            proyecto.EstadoAprobacion = new BuEstadoAprobacion().GetById(proyecto.EstadoAprobacionId);
            proyecto.Prioridad = new BuPrioridad().GetById(proyecto.PrioridadId);
            proyecto.Estado = new BuEstado().GetById(proyecto.EstadoId);
            proyecto.Cliente = new BuCliente().GetById(proyecto.ClienteId);
            proyecto.TipoProyecto = new BuTipoProyecto().GetById(proyecto.TipoProyectoId);
            proyecto.Responsable = new BuTrabajador().GetById(proyecto.ResponsableId);
            proyecto.Patrocinador = new BuPatrocinador().GetById(proyecto.PatrocinadorId);
            proyecto.TipoDuracion = new BuTipoDuracion().GetById(proyecto.TipoDuracionId);

            proyecto.Tareas = new BuTarea().GetTareasFullByProyectoId(proyecto.Id).ToList();
            proyecto.Equipo = proyecto.Tareas.Select(x => x.Responsable).Distinct().ToList();
            proyecto.SolicitudesRecurso = new BuSolicitudRecurso().GetSolicitudesFullByProyectoId(proyecto.Id).ToList();
            proyecto.Recursos = new List<Recurso>();
            foreach (var solicitudRecurso in proyecto.SolicitudesRecurso)
            {
                foreach (var detalle in solicitudRecurso.Recursos)
                    if (!proyecto.Recursos.Select(x => x.Id).Contains(detalle.RecursoId))
                        proyecto.Recursos.Add(detalle.Recurso);
            }

            if (loadStatisticalData)
            {
                //% TAREAS COMPLETADAS 
                proyecto.Duracion = proyecto.Tareas.Sum(x => x.Duracion);
                proyecto.Tareas.ToList().ForEach(x => x.Porcentaje = decimal.Round(x.Duracion / proyecto.Duracion * 100, 2));
                proyecto.Tareas.ToList().ForEach(x => x.Progreso = (x.EstadoId.Equals((int)Enums.EstadoType.Terminado)) ? x.Porcentaje : 0);
                proyecto.Progreso = proyecto.Tareas.Sum(x => x.Progreso);

                proyecto.TareasCompletadasData = new List<PieData>
                {
                    new PieData{ label = "Terminado", color = _verde, data = proyecto.Progreso },
                    new PieData{ label = "Pendiente", color = _plomo, data = 100 - proyecto.Progreso }
                };
                
                //PRESUPUESTO UTILIZADO
                proyecto.SolicitudesRecurso.ToList().ForEach(x => x.Recursos.ToList().ForEach(r => r.CostoTotal = decimal.Round(
                    r.TipoSolicitudRecursoId.Equals((int)Enums.TipoSolicitudRecursoType.Compra) 
                        ? r.Quantity * r.Recurso.CostoUnitario
                        : (r.Quantity * r.Recurso.CostoAlquiler) * r.DiasAlquiler.Value
                    , 2)));

                proyecto.PresupuestoUtilizado = proyecto.SolicitudesRecurso.ToList().Sum(x => x.Recursos.ToList().Sum(r => r.CostoTotal));

                proyecto.PresupuestoUtilizadoData = new List<BarData<decimal, int>>
                {
                    new BarData<decimal, int> { label = "Pre. Utilizado", color = _verde, data = new KeyValuePair<decimal, int>(proyecto.PresupuestoUtilizado, 0) },
                    new BarData<decimal, int> { label = "Presupuesto", color = _verdeClaro, data = new KeyValuePair<decimal, int>(proyecto.Presupuesto, 1)}
                };

                //TAREAS
                proyecto.TareasXResponsableData = new List<BarData<int, decimal>>();
                foreach (var trabajador in proyecto.Equipo)
                {
                    var total = proyecto.Tareas.Where(x => x.ResponsableId.Equals(trabajador.Id)).Sum(t => t.Porcentaje);
                    proyecto.TareasXResponsableData.Add( new BarData<int, decimal>{
                        label = trabajador.FullName,
                        color = _verde,
                        value0 = proyecto.Tareas.Count(x => x.ResponsableId.Equals(trabajador.Id)),
                        value1 = total,
                        data = new KeyValuePair<int, decimal>(trabajador.Id, total)});
                }

                //AVANCE
                var tareas = proyecto.Tareas.Where(x => x.FinalDate <= System.DateTime.Now).OrderBy(t => t.FinalDate);
                proyecto.AvanceTareasPlanificadoData = new List<BarData<int, decimal>>();
                proyecto.AvanceTareasActualData = new List<BarData<int, decimal>>();
                var planificado = 0m;
                var actual = 0m;
                foreach (var tarea in tareas)
                {
                    planificado += tarea.Porcentaje;
                    actual += tarea.Progreso;
                    var key = tarea.FinalDate.ToString("yyyy-MM-dd");
                    var keyValue = tarea.FinalDate.DayOfYear;
                    proyecto.AvanceTareasPlanificadoData.Add( new BarData<int, decimal>
                    {
                        label = tarea.Name,
                        color = _verde,
                        value2 = key,
                        value1 = planificado,
                        value3 = actual,
                        data = new KeyValuePair<int, decimal>(keyValue, planificado)
                    });
                    proyecto.AvanceTareasActualData.Add(new BarData<int, decimal>
                    {
                        label = tarea.Name,
                        color = _verde,
                        value2 = key,
                        value1 = planificado,
                        value3 = actual,
                        data = new KeyValuePair<int, decimal>(keyValue, actual)
                    });
                }

            }

            return proyecto;
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
                proyecto.EstadoAprobacion = estadoAprobaciones.FirstOrDefault(x => x.Id.Equals(proyecto.EstadoAprobacionId));
                proyecto.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(proyecto.PrioridadId));
                proyecto.Estado = estados.FirstOrDefault(x => x.Id.Equals(proyecto.EstadoId));
                proyecto.Cliente = buCliente.GetById(proyecto.ClienteId);
                proyecto.TipoProyecto = tipoProyectos.FirstOrDefault(x => x.Id.Equals(proyecto.TipoProyectoId));
                proyecto.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(proyecto.ResponsableId));
                proyecto.Patrocinador = buPatrocinador.GetById(proyecto.PatrocinadorId);

                var solicitudes = buSolicitudRecurso.GetMany(x => x.ProyectoId.Equals(proyecto.Id) && x.EstadoId.Equals((int)Enums.EstadoType.Pendiente));
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