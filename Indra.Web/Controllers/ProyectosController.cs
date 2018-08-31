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
    public class ProyectosController : Controller
    {
        public Proyecto GetProyecto(int id)
        {
            var proyecto = new BuProyecto().GetById(id);

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
                foreach (var detalle in solicitudRecurso.Recursos)
                    if (!proyecto.Recursos.Select(x => x.Id).Contains(detalle.RecursoId))
                        proyecto.Recursos.Add(detalle.Recurso);

            return proyecto;
        }

        public ActionResult Index(string search)
        {
            ViewBag.Message = TempData["Message"];

            var proyectos = new BuProyecto().GetAll();

            if (proyectos != null && !string.IsNullOrEmpty(search))
                proyectos = proyectos.Where(x => x.Name.Contains(search));

            if (proyectos != null)
            {
                var prioridades = new BuPrioridad().GetAll();
                var estados = new BuEstado().GetAll();
                var trabajadores = new BuTrabajador().GetAll();
                var tiposProyecto = new BuTipoProyecto().GetAll();
                foreach (var proyecto in proyectos)
                {
                    proyecto.Prioridad = prioridades.FirstOrDefault(x => x.Id.Equals(proyecto.PrioridadId));
                    proyecto.Estado = estados.FirstOrDefault(x => x.Id.Equals(proyecto.EstadoId));
                    proyecto.TipoProyecto = tiposProyecto.FirstOrDefault(x => x.Id.Equals(proyecto.TipoProyectoId));
                    proyecto.Responsable = trabajadores.FirstOrDefault(x => x.Id.Equals(proyecto.ResponsableId));
                }
            }
            else
                proyectos = new List<Proyecto>();

            return View(proyectos.OrderBy(x => x.Name));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var proyecto = GetProyecto(id.Value);

            if (proyecto == null)
                return HttpNotFound();

            return View(proyecto);
        }
    }
}