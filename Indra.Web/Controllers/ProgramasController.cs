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
    public class ProgramasController : Controller
    {
        public Programa GetPrograma(int id)
        {
            var buPrograma = new BuPrograma();
            var programa = buPrograma.GetById(id);

            if (programa == null)
                return null;

            var buProyecto = new BuProyecto();
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

            programa.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(programa.PrioridadId));
            programa.Estado = estados.FirstOrDefault(x => x.Id.Equals(programa.EstadoId));
            programa.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(programa.ResponsableId));

            programa.Proyectos = new BuProgramaDetalle().GetMany(x => x.ProgramaId.Equals(programa.Id)).ToList();
            foreach (var proyecto in programa.Proyectos)
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

            return programa;
        }

        public ActionResult Index(string search)
        {
            ViewBag.Message = TempData["Message"];

            var buPrograma = new BuPrograma();
            var programas = buPrograma.GetAll();

            if (programas != null && !string.IsNullOrEmpty(search))
                programas = programas.Where(x => x.Name.Contains(search));

            if (programas != null)
            {
                var prioridades = new BuPrioridad().GetAll();
                var estados = new BuEstado().GetAll();
                var trabajadores = new BuTrabajador().GetAll();
                foreach (var programa in programas)
                {
                    programa.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(programa.PrioridadId));
                    programa.Estado = estados.FirstOrDefault(x => x.Id.Equals(programa.EstadoId));
                    programa.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(programa.ResponsableId));
                }
            }
            else
                programas = new List<Programa>();

            return View(programas.OrderBy(x => x.Name));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var programa = GetPrograma(id.Value);

            if (programa == null)
                return HttpNotFound();

            return View(programa);
        }

        public ActionResult Create()
        {
            ViewBag.PrioridadId = new SelectList(new BuPrioridad().GetAll(), "Id", "Name");
            ViewBag.ResponsableId = new SelectList(new BuTrabajador().GetAll(), "Id", "Nombres");
            ViewBag.ProyectoId = new SelectList(new BuProyecto().GetAllForPortafolio(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Presupuesto,StarDate,FinalDate,PrioridadId,EstadoId,ResponsableId,Proyectos")] Programa programa)
        {
            try
            {
                if (programa.Proyectos == null || programa.Proyectos.Count().Equals(0))
                    throw new Exception("Necesita seleccionar proyectos.");

                if (string.IsNullOrEmpty(programa.Name))
                    throw new Exception("Necesita ingresar un nombre para el programa.");

                new BuPrograma().Add(programa);

                TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }

            ViewBag.PrioridadId = new SelectList(new BuPrioridad().GetAll(), "Id", "Name");
            ViewBag.ResponsableId = new SelectList(new BuTrabajador().GetAll(), "Id", "Nombres");
            ViewBag.ProyectoId = new SelectList(new BuProyecto().GetAllForPortafolio(), "Id", "Name");

            return View(programa);
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
    }
}