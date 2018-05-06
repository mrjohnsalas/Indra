using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuPropuestaBalanceo
    {
        private readonly IPropuestaBalanceoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuPropuestaBalanceo()
        {
            var db = new DbFactory();
            _repository = new PropuestaBalanceoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<PropuestaBalanceo> GetAll() => _repository.GetAll();

        public IEnumerable<PropuestaBalanceo> GetMany(Expression<Func<PropuestaBalanceo, bool>> where) => _repository.GetMany(where);

        public PropuestaBalanceo GetById(int id) => _repository.GetById(id);

        private string GetId(int year, int month)
        {
            var propuestas = GetMany(x => x.CreateDate.Year.Equals(year) && x.CreateDate.Month.Equals(month));
            var num = (propuestas?.Count() ?? 0) + 1;
            return $"PB-{year}-{month:00}-{num:00000}";
        }

        public PropuestaBalanceo Get(Expression<Func<PropuestaBalanceo, bool>> where) => _repository.Get(where);

        public void Add(Portafolio myObject)
        {
            var systemDate = DateTime.Now;
            //CREAR PROPUESTA
            var propuesta = new PropuestaBalanceo();
            propuesta.NumPropuesta = GetId(systemDate.Year, systemDate.Month);
            propuesta.PortafolioId = myObject.Id;
            propuesta.CreateDate = systemDate;
            propuesta.EstadoId = (int) EstadoType.Pendiente;
            propuesta.UserId = myObject.UserId;
            propuesta.PropuestaBalanceoDetalles = new List<PropuestaBalanceoDetalle>();
            foreach (var solicitud in myObject.PropuestaBalanceoDetalleViews)
                propuesta.PropuestaBalanceoDetalles.Add(new PropuestaBalanceoDetalle{ SolicitudRecursoDetalleId = solicitud.SolicitudRecursoId, Quantity = solicitud.Quantity });

            var buRecurso = new BuRecurso();
            var buSolicitudRecurso = new BuSolicitudRecurso();
            var buSolicitudRecursoDetalle = new BuSolicitudRecursoDetalle();
            var buAlmacenRecurso = new BuAlmacenRecurso();

            var solicitudRecursoDetalles = new List<SolicitudRecursoDetalle>();
            var almacenRecursos = new List<AlmacenRecurso>();
            foreach (var solicitudView in myObject.PropuestaBalanceoDetalleViews)
            {
                var solicitudRecurso = buSolicitudRecursoDetalle.GetById(solicitudView.SolicitudRecursoId);
                solicitudRecurso.Recurso = buRecurso.GetById(solicitudRecurso.RecursoId);
                
                //CHECK CANTIDAD ATENDIDA SOLICITUD
                if ((solicitudRecurso.QuantityAttended + solicitudView.Quantity) > solicitudRecurso.Quantity)
                    throw new Exception($"La cantidad atendida ({solicitudRecurso.QuantityAttended}) mas la cantidad a asignar ({solicitudView.Quantity}) es mayor ({solicitudRecurso.QuantityAttended + solicitudView.Quantity}) a la cantidad solicitada ({solicitudRecurso.Quantity}) del recurso: {solicitudRecurso.Recurso.Id} - {solicitudRecurso.Recurso.Name}.");
                solicitudRecurso.QuantityAttended += solicitudView.Quantity;
                solicitudRecursoDetalles.Add(solicitudRecurso);

                //CHECK CANTIDAD COMPROMETIDA ALMACEN RECURSO
                var almacenRecurso = buAlmacenRecurso.Get(x => x.AlmacenId.Equals(1) && x.RecursoId.Equals(solicitudRecurso.RecursoId));
                if ((almacenRecurso.StockCommitted + solicitudView.Quantity) > almacenRecurso.Stock)
                    throw new Exception($"El stock comprometido ({almacenRecurso.StockCommitted}) mas la cantidad a asignar ({solicitudView.Quantity}) es mayor ({almacenRecurso.StockCommitted + solicitudView.Quantity}) a el stock ({almacenRecurso.Stock}) del recurso: {solicitudRecurso.Recurso.Id} - {solicitudRecurso.Recurso.Name}.");
                almacenRecurso.StockCommitted += solicitudView.Quantity;
                almacenRecursos.Add(almacenRecurso);
            }
            
            Add(propuesta);
            foreach (var solicitudRecursoDetalle in solicitudRecursoDetalles)
                buSolicitudRecursoDetalle.Update(solicitudRecursoDetalle);
            foreach (var almacenRecurso in almacenRecursos)
                buAlmacenRecurso.Update(almacenRecurso);
        }

        public void Add(PropuestaBalanceo myObject)
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

        public void Update(PropuestaBalanceo myObject)
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
    }
}