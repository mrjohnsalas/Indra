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

        private readonly string _verde = "#1ab394";
        private readonly string _verdeClaro = "#79d2c0";
        private readonly string _plomo = "#bababa";

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

                //GET PROYECTOS AND PROGRAMAS
                var proyectos = new BuProyecto().GetMany(p => proyectosIdList.Contains(p.Id));
                var programas = new BuPrograma().GetMany(p => programasIdList.Contains(p.Id));
                //GET TIPODURACIONID
                myObject.TipoDuracionId = proyectos?.First().TipoDuracionId ?? programas.First().TipoDuracionId;
                //GET FIRST DATE
                var fechas = new List<DateTime>();
                if (proyectos != null)
                    fechas.AddRange(proyectos.Select(x => x.StarDate).Distinct());
                if (programas != null)
                    fechas.AddRange(programas.Select(x => x.StarDate).Distinct());
                myObject.StarDate = fechas.OrderBy(x => x).First();
                //GET LAST DATE
                fechas = new List<DateTime>();
                if (proyectos != null)
                    fechas.AddRange(proyectos.Select(x => x.FinalDate).Distinct());
                if (programas != null)
                    fechas.AddRange(programas.Select(x => x.FinalDate).Distinct());
                myObject.FinalDate = fechas.OrderBy(x => x).Last();
                //GET DURACION
                myObject.Duracion = (myObject.FinalDate - myObject.StarDate).Days;

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

                //GET PROYECTOS AND PROGRAMAS
                var proyectos = new BuProyecto().GetMany(p => proyectosIdList.Contains(p.Id));
                var programas = new BuPrograma().GetMany(p => programasIdList.Contains(p.Id));
                //GET TIPODURACIONID
                myObject.TipoDuracionId = proyectos?.First().TipoDuracionId ?? programas.First().TipoDuracionId;
                //GET FIRST DATE
                var fechas = new List<DateTime>();
                if (proyectos != null)
                    fechas.AddRange(proyectos.Select(x => x.StarDate).Distinct());
                if (programas != null)
                    fechas.AddRange(programas.Select(x => x.StarDate).Distinct());
                myObject.StarDate = fechas.OrderBy(x => x).First();
                //GET LAST DATE
                fechas = new List<DateTime>();
                if (proyectos != null)
                    fechas.AddRange(proyectos.Select(x => x.FinalDate).Distinct());
                if (programas != null)
                    fechas.AddRange(programas.Select(x => x.FinalDate).Distinct());
                myObject.FinalDate = fechas.OrderBy(x => x).Last();
                //GET DURACION
                myObject.Duracion = (myObject.FinalDate - myObject.StarDate).Days;

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

        public Portafolio GetFullById(int id, bool loadStadisticalData)
        {
            //portafolio.Programas = new BuPrograma().GetProgramasFullByPortafolioId(portafolio.Id).ToList();

            var portafolio = GetById(id);

            if (portafolio == null)
                return null;

            portafolio.CategoriaComponente = new BuCategoriaComponente().GetById(portafolio.CategoriaComponenteId);
            portafolio.Prioridad = new BuPrioridad().GetById(portafolio.PrioridadId);
            portafolio.Estado = new BuEstado().GetById(portafolio.EstadoId);
            portafolio.Responsable = new BuTrabajador().GetById(portafolio.ResponsableId);
            portafolio.TipoDuracion = new BuTipoDuracion().GetById(portafolio.TipoDuracionId);
            portafolio.Documentos = new BuDocumento().GetDocumentosFullByPortafolioId(portafolio.Id).ToList();

            portafolio.Proyectos = new BuProyecto().GetFullByProgramaIdOrPortafolioId(0, id);
            portafolio.Programas = new BuPrograma().GetFullByPortafolioId(id);

            var duracionTotal = 0m;
            if(portafolio.Proyectos != null)
                duracionTotal += portafolio.Proyectos.Sum(x => x.Duracion);
            if (portafolio.Programas != null)
                duracionTotal += portafolio.Programas.Sum(x => x.Duracion);

            if (loadStadisticalData)
            {
                //% PROYECTOS COMPLETADOS
                var progresoProyectos = portafolio.Proyectos == null ? 0 : decimal.Round(portafolio.Proyectos.Sum(t => (t.Progreso * (t.Duracion / duracionTotal * 100)) / 100), 2);
                var progresoProgramas = portafolio.Programas == null ? 0 : decimal.Round(portafolio.Programas.Sum(t => (t.Progreso * (t.Duracion / duracionTotal * 100)) / 100), 2);

                portafolio.Progreso = progresoProyectos + progresoProgramas;
                portafolio.ItemsCompletadosData = new List<PieData>
                {
                    new PieData{ label = "Proyectos", color = _verde, data = progresoProyectos },
                    new PieData{ label = "Programas", color = _verdeClaro, data = progresoProgramas },
                    new PieData{ label = "Pendiente", color = _plomo, data = 100 - portafolio.Progreso }
                };

                ////PRESUPUESTO UTILIZADO
                var presupuestoUtilizadoProyectos = portafolio.Proyectos?.ToList().Sum(x => x.PresupuestoUtilizado) ?? 0;
                var presupuestoUtilizadoProgramas = portafolio.Programas?.ToList().Sum(x => x.PresupuestoUtilizado) ?? 0;

                portafolio.Presupuesto = (portafolio.Proyectos?.ToList().Sum(x => x.Presupuesto) ?? 0) + (portafolio.Programas?.ToList().Sum(x => x.Presupuesto) ?? 0);
                portafolio.PresupuestoUtilizado = presupuestoUtilizadoProyectos + presupuestoUtilizadoProgramas;
                portafolio.PresupuestoUtilizadoData = new List<BarData<decimal, int>>
                {
                    new BarData<decimal, int> { label = "Pre. Utilizado", color = _verde, data = new KeyValuePair<decimal, int>(portafolio.PresupuestoUtilizado, 0) },
                    new BarData<decimal, int> { label = "Presupuesto", color = _verdeClaro, data = new KeyValuePair<decimal, int>(portafolio.Presupuesto, 1)}
                };

                //PROYECTOS
                portafolio.ItemsXResponsableData = new List<BarData<int, decimal>>();
                if (portafolio.Proyectos != null)
                {
                    foreach (var proyecto in portafolio.Proyectos)
                    {
                        var total = decimal.Round(portafolio.Proyectos.Where(x => x.ResponsableId.Equals(proyecto.Responsable.Id)).Sum(t => (t.Duracion / duracionTotal * 100)), 2);
                        portafolio.ItemsXResponsableData.Add(new BarData<int, decimal>
                        {
                            label = proyecto.Responsable.ShortName,
                            color = _verde,
                            value0 = portafolio.Proyectos.Count(x => x.ResponsableId.Equals(proyecto.Responsable.Id)),
                            value1 = total,
                            value2 = "Y",
                            data = new KeyValuePair<int, decimal>(proyecto.Responsable.Id, total)
                        });
                    }
                }

                if (portafolio.Programas != null)
                {
                    foreach (var programa in portafolio.Programas)
                    {
                        var total = decimal.Round(portafolio.Programas.Where(x => x.ResponsableId.Equals(programa.Responsable.Id)).Sum(t => (t.Duracion / duracionTotal * 100)), 2);
                        if (!portafolio.ItemsXResponsableData.Exists(x => x.label.Equals(programa.Responsable.ShortName)))
                        {
                            portafolio.ItemsXResponsableData.Add(new BarData<int, decimal>
                            {
                                label = programa.Responsable.ShortName,
                                color = _verde,
                                value0 = portafolio.Programas.Count(x => x.ResponsableId.Equals(programa.Responsable.Id)),
                                value1 = total,
                                value2 = "G",
                                data = new KeyValuePair<int, decimal>(programa.Responsable.Id, total)
                            });
                        }
                    }
                }


                ////AVANCE
                //var proyectos = programa.Proyectos.Where(x => x.FinalDate <= DateTime.Now).OrderBy(t => t.FinalDate);
                //var planificado = 0m;
                //var actual = 0m;
                //programa.AvanceProyectosData = new List<LineData<string, decimal>>
                //{
                //    new LineData<string, decimal> {label = "% Planificado", color = _verde, data = new List<KeyValuePair<string, decimal>>()},
                //    new LineData<string, decimal> {label = "% Actual", color = _plomo, data = new List<KeyValuePair<string, decimal>>()}
                //};
                //programa.AvanceProyectos = new List<AvanceTareasViewModel>();
                //foreach (var proyecto in proyectos)
                //{
                //    planificado += decimal.Round(proyecto.Duracion / duracionTotal * 100, 2);
                //    actual += decimal.Round((proyecto.Progreso * (proyecto.Duracion / duracionTotal * 100)) / 100, 2);
                //    var keyValue = proyecto.FinalDate.ToString("yyyy-MM-dd");
                //    programa.AvanceProyectos.Add(new AvanceTareasViewModel { Tarea = proyecto.Name, Fecha = keyValue, Planificado = planificado, Actual = actual });
                //    programa.AvanceProyectosData[0].data.Add(new KeyValuePair<string, decimal>(keyValue, planificado));
                //    programa.AvanceProyectosData[1].data.Add(new KeyValuePair<string, decimal>(keyValue, actual));
                //}
            }

            return portafolio;
        }
    }
}