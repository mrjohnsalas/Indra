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
        public Proyecto GetProyecto(int id, bool loadStatisticalData)
        {
            var proyecto = new BuProyecto().GetFullById(id, true);

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

            var proyecto = GetProyecto(id.Value, false);

            if (proyecto == null)
                return HttpNotFound();

            return View(proyecto);
        }

        public ActionResult Salud(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var proyecto = GetProyecto(id.Value, true);

            if (proyecto == null)
                return HttpNotFound();

            return View(proyecto);
        }
    }
}