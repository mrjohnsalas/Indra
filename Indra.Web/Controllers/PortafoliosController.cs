using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Indra.Business;
using Indra.Model.Models;
using Indra.Model.ViewModels;
using Microsoft.AspNet.Identity;

namespace Indra.Web.Controllers
{
    public class PortafoliosController : Controller
    {
        public Portafolio GetPortafolio(int id)
        {
            var buPortafolio = new BuPortafolio();
            var portafolio = buPortafolio.GetById(id);

            if (portafolio == null)
                return null;

            var prioridades = new BuPrioridad().GetAll();
            var estados = new BuEstado().GetAll();
            var trabajadores = new BuTrabajador().GetAll();

            portafolio.CategoriaComponente = new BuCategoriaComponente().GetById(portafolio.CategoriaComponenteId);
            portafolio.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(portafolio.PrioridadId));
            portafolio.Estado = estados.FirstOrDefault(x => x.Id.Equals(portafolio.EstadoId));
            portafolio.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(portafolio.ResponsableId));

            portafolio.Programas = new BuPrograma().GetProgramasFullByPortafolioId(portafolio.Id).ToList();
            portafolio.Proyectos = new BuProyecto().GetProyectosFullByPortafolioIdOrProgramaId(portafolio.Id, 0).ToList();
            portafolio.Documentos = new BuDocumento().GetDocumentosFullByPortafolioId(portafolio.Id).ToList();


            return portafolio;
        }

        public void LoadViewBags(Portafolio portafolio)
        {
            ViewBag.CategoriaComponenteId = portafolio == null 
                ? new SelectList(new BuCategoriaComponente().GetAll().OrderBy(x => x.Name), "Id", "Name") 
                : new SelectList(new BuCategoriaComponente().GetAll().OrderBy(x => x.Name), "Id", "Name", portafolio.CategoriaComponenteId);

            ViewBag.PrioridadId = portafolio == null
                ? new SelectList(new BuPrioridad().GetAll().OrderBy(x => x.Name), "Id", "Name")
                : new SelectList(new BuPrioridad().GetAll().OrderBy(x => x.Name), "Id", "Name", portafolio.PrioridadId);
            
            ViewBag.ResponsableId = portafolio == null
                ? new SelectList(new BuTrabajador().GetAll().OrderBy(x => x.Nombres), "Id", "Nombres")
                : new SelectList(new BuTrabajador().GetAll().OrderBy(x => x.Nombres), "Id", "Nombres", portafolio.ResponsableId);

            ViewBag.ResponsableIdDocumento = new SelectList(new BuTrabajador().GetAll().OrderBy(x => x.Nombres), "Id", "Nombres");

            ViewBag.ProgramaId = new SelectList(new BuPrograma().GetAllAvailable().OrderBy(x => x.NumAndName), "Id", "NumAndName");
            ViewBag.ProyectoId = new SelectList(new BuProyecto().GetAllAvailable().OrderBy(x => x.NumAndName), "Id", "NumAndName");
        }

        public ActionResult Index(string search)
        {
            ViewBag.Message = TempData["Message"];

            var buPortafolio = new BuPortafolio();
            var portafolios = buPortafolio.GetAll();

            if (portafolios != null && !string.IsNullOrEmpty(search))
                portafolios = portafolios.Where(x => x.Name.Contains(search));

            if (portafolios != null)
            {
                var categorias = new BuCategoriaComponente().GetAll();
                var prioridades = new BuPrioridad().GetAll();
                var estados = new BuEstado().GetAll();
                var trabajadores = new BuTrabajador().GetAll();
                foreach (var portafolio in portafolios)
                {
                    portafolio.CategoriaComponente = categorias.FirstOrDefault(x => x.Id.Equals(portafolio.CategoriaComponenteId));
                    portafolio.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(portafolio.PrioridadId));
                    portafolio.Estado = estados.FirstOrDefault(x => x.Id.Equals(portafolio.EstadoId));
                    portafolio.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(portafolio.ResponsableId));
                }
            }
            else
                portafolios = new List<Portafolio>();

            return View(portafolios.OrderBy(x => x.Name));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var portafolio = GetPortafolio(id.Value);

            if (portafolio == null)
                return HttpNotFound();

            return View(portafolio);
        }

        public ActionResult Create()
        {
            LoadViewBags(null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,CategoriaComponenteId,PrioridadId,EstadoId,ResponsableId,Remark,Programas,Proyectos")] Portafolio portafolio)
        {
            try
            {
                if (portafolio.Proyectos == null && portafolio.Programas == null)
                    throw new Exception("Necesita seleccionar programas y/o proyectos.");

                if (string.IsNullOrEmpty(portafolio.Name))
                    throw new Exception("Necesita ingresar un nombre para el portafolio.");

                portafolio.UserId = User.Identity.GetUserName();
                new BuPortafolio().Add(portafolio);

                TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }

            LoadViewBags(null);

            return View(portafolio);
        }

        [HttpPost]
        public JsonResult GetPrograma(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                var programa = new BuPrograma().GetById(int.Parse(id));
                return Json(programa, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetProyecto(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                var proyecto = new BuProyecto().GetById(int.Parse(id));
                return Json(proyecto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Message = ex.Message });
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var portafolio = GetPortafolio(id.Value);

            if (portafolio == null)
                return HttpNotFound();

            LoadViewBags(portafolio);

            return View(portafolio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumDocument,Name,Description,CategoriaComponenteId,PrioridadId,EstadoId,ResponsableId,Remark,CreateDate,EditDate,UserId,Programas,Proyectos")] Portafolio portafolio)
        {
            try
            {
                if(portafolio.Proyectos == null && portafolio.Programas == null)
                    throw new Exception("Necesita seleccionar programas y/o proyectos.");
            
                if (string.IsNullOrEmpty(portafolio.Name))
                    throw new Exception("Necesita ingresar un nombre para el portafolio.");

                new BuPortafolio().Update(portafolio);

                TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }

            LoadViewBags(null);

            return View(portafolio);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var portafolio = GetPortafolio(id.Value);

            if (portafolio == null)
                return HttpNotFound();

            return View(portafolio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var portafolio = GetPortafolio(id);

                if (portafolio == null)
                    return HttpNotFound();

                new BuPortafolio().Delete(portafolio.Id);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult UploadFile()
        {
            if (!Request.Files.AllKeys.Any()) return Json(new { Result = "Error" }); ;

            var file = Request.Files["UploadedFile"];

            var documento = new Documento
            {
                PortafolioId = int.Parse(Request.Form["PortafolioId"]),
                ResponsableId = int.Parse(Request.Form["ResponsableId"]),
                RemarkDocumento = Request.Form["Remark"],
                UserId = User.Identity.GetUserName(),
                FileName = Path.GetFileNameWithoutExtension(file.FileName),
                FileExtension = Path.GetExtension(file.FileName),
                ContentType = file.ContentType
            };
            using (var reader = new BinaryReader(file.InputStream))
                documento.Content = reader.ReadBytes(file.ContentLength);
            
            try
            {
                var buDocumento = new BuDocumento();
                documento.Id = buDocumento.Add(documento);
                documento.Responsable = new BuTrabajador().GetById(documento.ResponsableId);
                return Json(documento, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Message = ex.Message });
            }
        }

        public FileResult DownloadFile(int? id)
        {
            var documento = new BuDocumento().GetById(id.Value);
            return File(documento.Content, System.Net.Mime.MediaTypeNames.Application.Octet, documento.FullFileName);
        }

        [HttpPost]
        public JsonResult DeleteFile(int? id)
        {
            if (!id.HasValue)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                new BuDocumento().Delete(id.Value);
                return Json(new { Result = "Ok" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Message = ex.Message });
            }
        }

        #region Balanceo

        public ActionResult IndexBalanceo(string search)
        {
            ViewBag.Message = TempData["Message"];

            var buPortafolio = new BuPortafolio();
            var portafolios = buPortafolio.GetAllForPropuesta();

            if (portafolios != null && !string.IsNullOrEmpty(search))
                portafolios = portafolios.Where(x => x.Name.Contains(search));

            if (portafolios != null)
            {
                var categorias = new BuCategoriaComponente().GetAll();
                var prioridades = new BuPrioridad().GetAll();
                var estados = new BuEstado().GetAll();
                var trabajadores = new BuTrabajador().GetAll();
                foreach (var portafolio in portafolios)
                {
                    portafolio.CategoriaComponente = categorias.FirstOrDefault(x => x.Id.Equals(portafolio.CategoriaComponenteId));
                    portafolio.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(portafolio.PrioridadId));
                    portafolio.Estado = estados.FirstOrDefault(x => x.Id.Equals(portafolio.EstadoId));
                    portafolio.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(portafolio.ResponsableId));
                }
            }
            else
                portafolios = new List<Portafolio>();

            return View(portafolios.OrderBy(x => x.Name));
        }

        public ActionResult DetailsBalanceo(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var portafolio = GetPortafolio(id.Value);

            if (portafolio == null)
                return HttpNotFound();

            return View(portafolio);
        }

        public ActionResult CreateBalanceo(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var portafolio = GetPortafolio(id.Value);

            if (portafolio == null)
                return HttpNotFound();

            return View(portafolio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBalanceo([Bind(Include = "Id,NumDocument,Name,Description,CreateDate,EditDate,CategoriaComponenteId,PrioridadId,EstadoId,ResponsableId,Remark,PropuestaBalanceoDetalleViews")] Portafolio portafolio)
        {
            try
            {
                //VERIFICAR QUE HAY SOLICITUDES
                if (portafolio.PropuestaBalanceoDetalleViews == null)
                    throw new Exception("No hay solicitudes para este portafolio.");

                //VERIFICAR QUE NO SE REPITAN Y QUE TENGAN CANTIDAD ASIGNADA
                var propuestaDetalle = new List<PropuestaBalanceoDetalleView>();
                foreach (var solicitud in portafolio.PropuestaBalanceoDetalleViews)
                {
                    var propuesta = propuestaDetalle.Find(x => x.SolicitudRecursoId.Equals(solicitud.SolicitudRecursoId));
                    if (propuesta == null)
                        if (solicitud.Quantity > 0)
                            propuestaDetalle.Add(solicitud);
                }

                //VERIFICAR QUE HAY SOLICITUDES CON CANTIDAD ASIGNADA
                if (propuestaDetalle.Count().Equals(0))
                    throw new Exception("No hay solicitudes para este portafolio.");

                portafolio.PropuestaBalanceoDetalleViews = propuestaDetalle;
                portafolio.UserId = User.Identity.GetUserName();

                //GRABAR PROPUESTA
                var buPropuestaBalanceo = new BuPropuestaBalanceo();
                buPropuestaBalanceo.Add(portafolio);

                TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                return RedirectToAction("IndexBalanceo", "Portafolios");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }

            portafolio = GetPortafolio(portafolio.Id);

            return View(portafolio);
        }

        #endregion
    }
}