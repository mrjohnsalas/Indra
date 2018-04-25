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
    public class CategoriaComponentesController : Controller
    {
        public ActionResult Index(string search)
        {
            ViewBag.Message = TempData["Message"];

            var buCategoriaComponente = new BuCategoriaComponente();
            var categoriaComponentes = string.IsNullOrEmpty(search) ? buCategoriaComponente.GetAll() : buCategoriaComponente.GetMany(x => x.Name.Contains(search));
            return View(categoriaComponentes.OrderBy(x => x.Name));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var buCategoriaComponente = new BuCategoriaComponente();
            var categoriaComponente = buCategoriaComponente.GetById(id.Value);

            if (categoriaComponente == null)
                return HttpNotFound();

            return View(categoriaComponente);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Description,Remark")] CategoriaComponente categoriaComponente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var buCategoriaComponente = new BuCategoriaComponente();
                    buCategoriaComponente.Add(categoriaComponente);
                    TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }
            return View(categoriaComponente);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var buCategoriaComponente = new BuCategoriaComponente();
            var categoriaComponente = buCategoriaComponente.GetById(id.Value);

            if (categoriaComponente == null)
                return HttpNotFound();

            return View(categoriaComponente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description,Remark")] CategoriaComponente categoriaComponente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var buCategoriaComponente = new BuCategoriaComponente();
                    buCategoriaComponente.Update(categoriaComponente);
                    TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }
            return View(categoriaComponente);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var buCategoriaComponente = new BuCategoriaComponente();
            var categoriaComponente = buCategoriaComponente.GetById(id.Value);

            if (categoriaComponente == null)
                return HttpNotFound();

            return View(categoriaComponente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var buCategoriaComponente = new BuCategoriaComponente();
            var categoriaComponente = buCategoriaComponente.GetById(id);
            if (categoriaComponente == null)
                return HttpNotFound();
            try
            {
                buCategoriaComponente.Delete(id);
                TempData["Message"] = "Message: La operación se realizó satisfactoriamente.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = $"Error Message: {e.Message}";
            }

            return View(categoriaComponente);
        }
    }
}
