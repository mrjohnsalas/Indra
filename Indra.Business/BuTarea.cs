using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuTarea
    {
        private readonly ITareaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuTarea()
        {
            var db = new DbFactory();
            _repository = new TareaRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Tarea> GetAll() => _repository.GetAll();

        public IEnumerable<Tarea> GetMany(Expression<Func<Tarea, bool>> where) => _repository.GetMany(where);

        public Tarea GetById(int id) => _repository.GetById(id);

        public Tarea Get(Expression<Func<Tarea, bool>> where) => _repository.Get(where);

        public void Add(Tarea myObject)
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

        public void Update(Tarea myObject)
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

        public IEnumerable<Tarea> GetTareasFullByProyectoId(int proyectoId)
        {
            var tareas = GetMany(x => x.ProyectoId.Equals(proyectoId)).ToList();

            var tipoDuraciones = new BuTipoDuracion().GetAll();
            var estados = new BuEstado().GetAll();
            var trabajadores = new BuTrabajador().GetAll();
            
            foreach (var tarea in tareas)
            {
                tarea.TipoDuracion = tipoDuraciones.FirstOrDefault(x => x.Id.Equals(tarea.TipoDuracionId));
                tarea.Estado = estados.FirstOrDefault(x => x.Id.Equals(tarea.EstadoId));
                tarea.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(tarea.ResponsableId));
            }

            return tareas;
        }
    }
}