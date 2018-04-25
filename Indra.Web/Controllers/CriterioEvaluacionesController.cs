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

namespace Indra.Web.Controllers
{
    public class CriterioEvaluacionesController : Controller
    {
        public ActionResult Index(string search)
        {
            ViewBag.Message = TempData["Message"];

            var buCriterioEvaluacion = new BuCriterioEvaluacion();
            var criterioEvaluaciones = string.IsNullOrEmpty(search) ? buCriterioEvaluacion.GetAll() : buCriterioEvaluacion.GetMany(x => x.Name.Contains(search));
            return View(criterioEvaluaciones.OrderBy(x => x.Name));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var buCriterioEvaluacion = new BuCriterioEvaluacion();
            var criterioEvaluacion = buCriterioEvaluacion.GetById(id.Value);

            if (criterioEvaluacion == null)
                return HttpNotFound();

            return View(criterioEvaluacion);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Description")] CriterioEvaluacion criterioEvaluacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var buCriterioEvaluacion = new BuCriterioEvaluacion();
                    buCriterioEvaluacion.Add(criterioEvaluacion);
                    TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }
            return View(criterioEvaluacion);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var buCriterioEvaluacion = new BuCriterioEvaluacion();
            var criterioEvaluacion = buCriterioEvaluacion.GetById(id.Value);

            if (criterioEvaluacion == null)
                return HttpNotFound();

            return View(criterioEvaluacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description")] CriterioEvaluacion criterioEvaluacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var buCriterioEvaluacion = new BuCriterioEvaluacion();
                    buCriterioEvaluacion.Update(criterioEvaluacion);
                    TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }
            return View(criterioEvaluacion);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var buCriterioEvaluacion = new BuCriterioEvaluacion();
            var criterioEvaluacion = buCriterioEvaluacion.GetById(id.Value);

            if (criterioEvaluacion == null)
                return HttpNotFound();

            return View(criterioEvaluacion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var buCriterioEvaluacion = new BuCriterioEvaluacion();
            var criterioEvaluacion = buCriterioEvaluacion.GetById(id);
            if (criterioEvaluacion == null)
                return HttpNotFound();
            try
            {
                buCriterioEvaluacion.Delete(id);
                TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }

            return View(criterioEvaluacion);
        }
    }
}