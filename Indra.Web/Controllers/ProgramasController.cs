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
        public Programa GetPrograma(int id, bool loadStatisticalData)
        {
            var programa = new BuPrograma().GetFullById(id, loadStatisticalData);

            return programa;
        }

        public void LoadViewBags(Programa programa)
        {
            ViewBag.PrioridadId = programa == null
                ? new SelectList(new BuPrioridad().GetAll().OrderBy(x => x.Name), "Id", "Name")
                : new SelectList(new BuPrioridad().GetAll().OrderBy(x => x.Name), "Id", "Name", programa.PrioridadId);

            ViewBag.ResponsableId = programa == null
                ? new SelectList(new BuTrabajador().GetAll().OrderBy(x => x.Nombres), "Id", "Nombres")
                : new SelectList(new BuTrabajador().GetAll().OrderBy(x => x.Nombres), "Id", "Nombres", programa.ResponsableId);

            ViewBag.ProyectoId = new SelectList(new BuProyecto().GetAllAvailable().OrderBy(x => x.NumAndName), "Id", "NumAndName");
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

            var programa = GetPrograma(id.Value, false);

            if (programa == null)
                return HttpNotFound();

            return View(programa);
        }

        public ActionResult Salud(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var programa = GetPrograma(id.Value, true);

            if (programa == null)
                return HttpNotFound();

            return View(programa);
        }

        public ActionResult Create()
        {
            LoadViewBags(null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Presupuesto,StarDate,FinalDate,PrioridadId,EstadoId,ResponsableId,TipoDuracionId,Duracion,Proyectos")] Programa programa)
        {
            try
            {
                if (programa.Proyectos == null || programa.Proyectos.Count().Equals(0))
                    throw new Exception("Necesita seleccionar proyectos.");

                if (string.IsNullOrEmpty(programa.Name))
                    throw new Exception("Necesita ingresar un nombre para el programa.");

                programa.UserId = User.Identity.GetUserName();
                new BuPrograma().Add(programa);

                TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }

            LoadViewBags(null);

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

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var programa = GetPrograma(id.Value, false);

            if (programa == null)
                return HttpNotFound();

            LoadViewBags(programa);

            return View(programa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumDocument,Name,Description,Presupuesto,StarDate,FinalDate,PrioridadId,EstadoId,ResponsableId,TipoDuracionId,Duracion,CreateDate,EditDate,UserId,Proyectos")] Programa programa)
        {
            try
            {
                if (programa.Proyectos == null || programa.Proyectos.Count().Equals(0))
                    throw new Exception("Necesita seleccionar proyectos.");

                if (string.IsNullOrEmpty(programa.Name))
                    throw new Exception("Necesita ingresar un nombre para el programa.");

                new BuPrograma().Update(programa);

                TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }

            LoadViewBags(null);

            return View(programa);
        }


        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var programa = GetPrograma(id.Value, false);

            if (programa == null)
                return HttpNotFound();

            return View(programa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var programa = GetPrograma(id, false);

                if (programa == null)
                    return HttpNotFound();

                new BuPrograma().Delete(programa.Id);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}