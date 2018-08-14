using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

            var categorias = new BuCategoriaComponente().GetAll();
            var prioridades = new BuPrioridad().GetAll();
            var estados = new BuEstado().GetAll();
            var estadoAprobaciones = new BuEstadoAprobacion().GetAll();
            var trabajadores = new BuTrabajador().GetAll();
            var tipoProyectos = new BuTipoProyecto().GetAll();

            portafolio.CategoriaComponente = categorias.FirstOrDefault(x => x.Id.Equals(portafolio.CategoriaComponenteId));
            portafolio.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(portafolio.PrioridadId));
            portafolio.Estado = estados.FirstOrDefault(x => x.Id.Equals(portafolio.EstadoId));
            portafolio.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(portafolio.ResponsableId));

            var buPrograma = new BuPrograma();
            portafolio.Programas = new BuPortafolioDetallePrograma().GetMany(x => x.PortafolioId.Equals(portafolio.Id)).ToList();
            foreach (var programa in portafolio.Programas)
            {
                programa.Programa = buPrograma.GetById(programa.ProgramaId);
                programa.Programa.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(programa.Programa.PrioridadId));
                programa.Programa.Estado = estados.FirstOrDefault(x => x.Id.Equals(programa.Programa.EstadoId));
                programa.Programa.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(programa.Programa.ResponsableId));
            }

            var buProyecto = new BuProyecto();
            var buCliente = new BuCliente();
            var buPatrocinador = new BuPatrocinador();
            var buRecurso = new BuRecurso();
            var buSolicitudRecurso = new BuSolicitudRecurso();
            var buSolicitudRecursoDetalle = new BuSolicitudRecursoDetalle();
            var buAlmacenRecurso = new BuAlmacenRecurso();

            portafolio.Proyectos = new BuPortafolioDetalleProyecto().GetMany(x => x.PortafolioId.Equals(portafolio.Id)).ToList();
            foreach (var proyecto in portafolio.Proyectos)
            {
                proyecto.Proyecto = buProyecto.GetById(proyecto.ProyectoId);
                proyecto.Proyecto.EstadoAprobacion = estadoAprobaciones.FirstOrDefault(x => x.Id.Equals(proyecto.Proyecto.EstadoAprobacionId));
                proyecto.Proyecto.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(proyecto.Proyecto.PrioridadId));
                proyecto.Proyecto.Estado = estados.FirstOrDefault(x => x.Id.Equals(proyecto.Proyecto.EstadoId));
                proyecto.Proyecto.Cliente = buCliente.GetById(proyecto.Proyecto.ClienteId);
                proyecto.Proyecto.TipoProyecto = tipoProyectos.FirstOrDefault(x => x.Id.Equals(proyecto.Proyecto.TipoProyectoId));
                proyecto.Proyecto.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(proyecto.Proyecto.ResponsableId));
                proyecto.Proyecto.Patrocinador = buPatrocinador.GetById(proyecto.Proyecto.PatrocinadorId);
                var solicitudes = buSolicitudRecurso.GetMany(x => x.ProyectoId.Equals(proyecto.ProyectoId) && x.EstadoId.Equals((int)EstadoType.Pendiente));
                if (solicitudes != null)
                {
                    proyecto.Proyecto.SolicitudRecursos = solicitudes.ToList();
                    foreach (var solicitud in proyecto.Proyecto.SolicitudRecursos)
                    {
                        solicitud.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(solicitud.PrioridadId));
                        var detallesSolicitud = buSolicitudRecursoDetalle.GetMany(x => x.SolicitudRecursoId.Equals(solicitud.Id));
                        if (detallesSolicitud != null)
                        {
                            solicitud.SolicitudRecursoDetalles = detallesSolicitud.ToList();
                            foreach (var detalle in solicitud.SolicitudRecursoDetalles)
                            {
                                detalle.Recurso = buRecurso.GetById(detalle.RecursoId);
                                detalle.QuantityAvailable = buAlmacenRecurso.Get(x => x.AlmacenId.Equals(1) && x.RecursoId.Equals(detalle.RecursoId)).StockAvailable;
                                detalle.QuantityToAssign = (detalle.QuantityAvailable > detalle.QuantityPending) ? detalle.QuantityPending : detalle.QuantityAvailable;
                            }
                        }
                    }
                }
            }

            return portafolio;
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
            ViewBag.CategoriaComponenteId = new SelectList(new BuCategoriaComponente().GetAll(), "Id", "Name");
            ViewBag.PrioridadId = new SelectList(new BuPrioridad().GetAll(), "Id", "Name");
            ViewBag.ResponsableId = new SelectList(new BuTrabajador().GetAll(), "Id", "Nombres");
            ViewBag.ProgramaId = new SelectList(new BuPrograma().GetAllForPortafolio(), "Id", "Name");
            ViewBag.ProyectoId = new SelectList(new BuProyecto().GetAllForPortafolio(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,CreateDate,EditDate,CategoriaComponenteId,PrioridadId,EstadoId,ResponsableId,Remark,Programas,Proyectos")] Portafolio portafolio)
        {
            try
            {
                if (portafolio.Programas == null && portafolio.Proyectos == null)
                    throw new Exception("Necesita seleccionar programas y/o proyectos.");
                if (portafolio.Programas.Count().Equals(0) && portafolio.Proyectos.Count().Equals(0))
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

            ViewBag.CategoriaComponenteId = new SelectList(new BuCategoriaComponente().GetAll(), "Id", "Name");
            ViewBag.PrioridadId = new SelectList(new BuPrioridad().GetAll(), "Id", "Name");
            ViewBag.ResponsableId = new SelectList(new BuTrabajador().GetAll(), "Id", "Nombres");
            ViewBag.ProgramaId = new SelectList(new BuPrograma().GetAllForPortafolio(), "Id", "Name");
            ViewBag.ProyectoId = new SelectList(new BuProyecto().GetAllForPortafolio(), "Id", "Name");

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
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Portafolio portafolio = db.Portafolios.Find(id);
            //if (portafolio == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name", portafolio.CategoriaComponenteId);
            //ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name", portafolio.EstadoId);
            //ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name", portafolio.PrioridadId);
            //ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres", portafolio.ResponsableId);
            return View(new Portafolio());
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="Id,NumPortafolio,Name,Description,CreateDate,EditDate,CategoriaComponenteId,PrioridadId,EstadoId,ResponsableId,Remark")] Portafolio portafolio)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(portafolio).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name", portafolio.CategoriaComponenteId);
        //    ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name", portafolio.EstadoId);
        //    ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name", portafolio.PrioridadId);
        //    ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres", portafolio.ResponsableId);
        //    return View(portafolio);
        //}

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var portafolio = GetPortafolio(id.Value);

            if (portafolio == null)
                return HttpNotFound();

            return View(portafolio);
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Portafolio portafolio = db.Portafolios.Find(id);
        //    db.Portafolios.Remove(portafolio);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
        public ActionResult CreateBalanceo([Bind(Include = "Id,NumPortafolio,Name,Description,CreateDate,EditDate,CategoriaComponenteId,PrioridadId,EstadoId,ResponsableId,Remark,PropuestaBalanceoDetalleViews")] Portafolio portafolio)
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