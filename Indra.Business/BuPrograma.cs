using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;
using Indra.Model.ViewModels;

namespace Indra.Business
{
    public class BuPrograma
    {
        private readonly IProgramaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _verde = "#1ab394";
        private readonly string _verdeClaro = "#79d2c0";
        private readonly string _plomo = "#bababa";

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

                var proyectos = new BuProyecto().GetMany(p => proyectosIdList.Contains(p.Id));
                myObject.TipoDuracionId = proyectos.First().TipoDuracionId;
                myObject.StarDate = proyectos.OrderBy(x => x.StarDate).First().StarDate;
                myObject.FinalDate = proyectos.OrderBy(x => x.FinalDate).Last().FinalDate;
                myObject.Duracion = (myObject.FinalDate - myObject.StarDate).Days;

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

                var proyectos = new BuProyecto().GetMany(p => proyectosIdList.Contains(p.Id));
                myObject.TipoDuracionId = proyectos.First().TipoDuracionId;
                myObject.StarDate = proyectos.OrderBy(x => x.StarDate).First().StarDate;
                myObject.FinalDate = proyectos.OrderBy(x => x.FinalDate).Last().FinalDate;
                myObject.Duracion = (myObject.FinalDate - myObject.StarDate).Days;

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

        public Programa GetFullById(int id, bool loadStadisticalData)
        {
            var programa = GetById(id);

            if (programa == null)
                return null;

            programa.Prioridad = new BuPrioridad().GetById(programa.PrioridadId);
            programa.Estado = new BuEstado().GetById(programa.EstadoId);
            programa.Responsable = new BuTrabajador().GetById(programa.ResponsableId);
            programa.TipoDuracion = new BuTipoDuracion().GetById(programa.TipoDuracionId);

            programa.Proyectos = new BuProyecto().GetFullByProgramaId(id);

            var duracionTotal = programa.Proyectos.Sum(x => x.Duracion);
            if (loadStadisticalData)
            {
                //% PROYECTOS COMPLETADOS
                programa.Progreso = decimal.Round(programa.Proyectos.Sum(t => (t.Progreso * (t.Duracion / duracionTotal * 100)) / 100), 2);
                programa.ProyectosCompletadosData = new List<PieData>
                {
                    new PieData{ label = "Terminado", color = _verde, data = programa.Progreso },
                    new PieData{ label = "Pendiente", color = _plomo, data = 100 - programa.Progreso }
                };

                //PRESUPUESTO UTILIZADO
                programa.PresupuestoUtilizado = programa.Proyectos.ToList().Sum(x => x.PresupuestoUtilizado);
                programa.PresupuestoUtilizadoData = new List<BarData<decimal, int>>
                {
                    new BarData<decimal, int> { label = "Pre. Utilizado", color = _verde, data = new KeyValuePair<decimal, int>(programa.PresupuestoUtilizado, 0) },
                    new BarData<decimal, int> { label = "Presupuesto", color = _verdeClaro, data = new KeyValuePair<decimal, int>(programa.Presupuesto, 1)}
                };

                //PROYECTOS
                programa.ProyectosXResponsableData = new List<BarData<int, decimal>>();
                foreach (var proyecto in programa.Proyectos)
                {
                    var total = decimal.Round(programa.Proyectos.Where(x => x.ResponsableId.Equals(proyecto.Responsable.Id)).Sum(t => (t.Duracion / duracionTotal * 100)), 2);
                    programa.ProyectosXResponsableData.Add(new BarData<int, decimal>
                    {
                        label = proyecto.Responsable.FullName,
                        color = _verde,
                        value0 = programa.Proyectos.Count(x => x.ResponsableId.Equals(proyecto.Responsable.Id)),
                        value1 = total,
                        data = new KeyValuePair<int, decimal>(proyecto.Responsable.Id, total)
                    });
                }

                //AVANCE
                var proyectos = programa.Proyectos.Where(x => x.FinalDate <= DateTime.Now).OrderBy(t => t.FinalDate);
                var planificado = 0m;
                var actual = 0m;
                programa.AvanceProyectosData = new List<LineData<string, decimal>>
                {
                    new LineData<string, decimal> {label = "% Planificado", color = _verde, data = new List<KeyValuePair<string, decimal>>()},
                    new LineData<string, decimal> {label = "% Actual", color = _plomo, data = new List<KeyValuePair<string, decimal>>()}
                };
                programa.AvanceProyectos = new List<AvanceTareasViewModel>();
                foreach (var proyecto in proyectos)
                {
                    planificado += decimal.Round(proyecto.Duracion / duracionTotal * 100, 2);
                    actual += decimal.Round((proyecto.Progreso * (proyecto.Duracion / duracionTotal * 100)) / 100, 2);
                    var keyValue = proyecto.FinalDate.ToString("yyyy-MM-dd");
                    programa.AvanceProyectos.Add(new AvanceTareasViewModel { Tarea = proyecto.Name, Fecha = keyValue, Planificado = planificado, Actual = actual });
                    programa.AvanceProyectosData[0].data.Add(new KeyValuePair<string, decimal>(keyValue, planificado));
                    programa.AvanceProyectosData[1].data.Add(new KeyValuePair<string, decimal>(keyValue, actual));
                }
            }

            return programa;
        }

    }
}