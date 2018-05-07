using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Service
{
    public class PatrocinadorService
    {
        #region Fields

        //public ActionResult Create()
        //{
        //    ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name");
        //    ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name");
        //    ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name");
        //    ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,NumPortafolio,Name,Description,CreateDate,EditDate,CategoriaComponenteId,PrioridadId,EstadoId,ResponsableId,Remark")] Portafolio portafolio)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Portafolios.Add(portafolio);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name", portafolio.CategoriaComponenteId);
        //    ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name", portafolio.EstadoId);
        //    ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name", portafolio.PrioridadId);
        //    ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres", portafolio.ResponsableId);
        //    return View(portafolio);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Portafolio portafolio = db.Portafolios.Find(id);
        //    if (portafolio == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name", portafolio.CategoriaComponenteId);
        //    ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name", portafolio.EstadoId);
        //    ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name", portafolio.PrioridadId);
        //    ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres", portafolio.ResponsableId);
        //    return View(portafolio);
        //}

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

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Portafolio portafolio = db.Portafolios.Find(id);
        //    if (portafolio == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(portafolio);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Portafolio portafolio = db.Portafolios.Find(id);
        //    db.Portafolios.Remove(portafolio);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        #endregion

        #region Methods

        //public ActionResult Create()
        //{
        //    ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name");
        //    ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name");
        //    ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name");
        //    ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,NumPortafolio,Name,Description,CreateDate,EditDate,CategoriaComponenteId,PrioridadId,EstadoId,ResponsableId,Remark")] Portafolio portafolio)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Portafolios.Add(portafolio);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name", portafolio.CategoriaComponenteId);
        //    ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name", portafolio.EstadoId);
        //    ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name", portafolio.PrioridadId);
        //    ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres", portafolio.ResponsableId);
        //    return View(portafolio);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Portafolio portafolio = db.Portafolios.Find(id);
        //    if (portafolio == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name", portafolio.CategoriaComponenteId);
        //    ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name", portafolio.EstadoId);
        //    ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name", portafolio.PrioridadId);
        //    ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres", portafolio.ResponsableId);
        //    return View(portafolio);
        //}

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

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Portafolio portafolio = db.Portafolios.Find(id);
        //    if (portafolio == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(portafolio);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Portafolio portafolio = db.Portafolios.Find(id);
        //    db.Portafolios.Remove(portafolio);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        #endregion

        #region Services

        //public ActionResult Create()
        //{
        //    ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name");
        //    ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name");
        //    ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name");
        //    ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,NumPortafolio,Name,Description,CreateDate,EditDate,CategoriaComponenteId,PrioridadId,EstadoId,ResponsableId,Remark")] Portafolio portafolio)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Portafolios.Add(portafolio);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name", portafolio.CategoriaComponenteId);
        //    ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name", portafolio.EstadoId);
        //    ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name", portafolio.PrioridadId);
        //    ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres", portafolio.ResponsableId);
        //    return View(portafolio);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Portafolio portafolio = db.Portafolios.Find(id);
        //    if (portafolio == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoriaComponenteId = new SelectList(db.CategoriaComponentes, "Id", "Name", portafolio.CategoriaComponenteId);
        //    ViewBag.EstadoId = new SelectList(db.Estadoes, "Id", "Name", portafolio.EstadoId);
        //    ViewBag.PrioridadId = new SelectList(db.Prioridads, "Id", "Name", portafolio.PrioridadId);
        //    ViewBag.ResponsableId = new SelectList(db.Trabajadors, "Id", "Nombres", portafolio.ResponsableId);
        //    return View(portafolio);
        //}

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

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Portafolio portafolio = db.Portafolios.Find(id);
        //    if (portafolio == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(portafolio);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Portafolio portafolio = db.Portafolios.Find(id);
        //    db.Portafolios.Remove(portafolio);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        #endregion
    }
}
