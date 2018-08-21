using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Indra.Data.Infrastructure;
using Indra.Data.Repositories;
using Indra.Model.Models;

namespace Indra.Business
{
    public class BuDocumento
    {
        private readonly IDocumentoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BuDocumento()
        {
            var db = new DbFactory();
            _repository = new DocumentoRepository(db);
            _unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Documento> GetAll() => _repository.GetAll();

        public IEnumerable<Documento> GetMany(Expression<Func<Documento, bool>> where) => _repository.GetMany(where);

        public Documento GetById(int id) => _repository.GetById(id);

        public Documento Get(Expression<Func<Documento, bool>> where) => _repository.Get(where);

        private string GetId(int year, int month, int portafolioId)
        {
            var documentos = GetMany(x => x.PortafolioId.HasValue && x.PortafolioId.Value.Equals(portafolioId) && x.CreateDate.Year.Equals(year) && x.CreateDate.Month.Equals(month));
            var num = (documentos?.Count() ?? 0) + 1;
            return $"DO-{year}-{month:00}-{num:00000}";
        }

        public int Add(Documento myObject)
        {
            try
            {
                var systemDate = DateTime.Now;
                myObject.NumDocument = GetId(systemDate.Year, systemDate.Month, myObject.PortafolioId.Value);
                myObject.CreateDate = systemDate;
                myObject.EditDate = systemDate;

                _repository.Add(myObject);
                _unitOfWork.Commit();

                return Get(x => x.NumDocument.Equals(myObject.NumDocument)).Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Documento myObject)
        {
            try
            {
                var systemDate = DateTime.Now;
                myObject.EditDate = systemDate;

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

        public IEnumerable<Documento> GetDocumentosFullByPortafolioId(int portafolioId)
        {
            var documentos = GetMany(x => x.PortafolioId.HasValue && x.PortafolioId.Value.Equals(portafolioId)).ToList();

            var trabajadores = new BuTrabajador().GetAll();

            foreach (var documento in documentos)
                documento.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(documento.ResponsableId));

            return documentos;
        }
    }
}