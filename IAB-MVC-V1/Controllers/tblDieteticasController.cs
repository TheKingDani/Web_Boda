using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IAB_MVC_V1.Models;

namespace IAB_MVC_V1.Controllers
{
    public class tblDieteticasController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblDieteticas
        public ActionResult Index()
        {
            return View(db.tblDieteticas.ToList());
        }

        // GET: tblDieteticas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDieteticas tblDieteticas = db.tblDieteticas.Find(id);
            if (tblDieteticas == null)
            {
                return HttpNotFound();
            }
            return View(tblDieteticas);
        }

        // GET: tblDieteticas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblDieteticas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDietetica,nomDietetica")] tblDieteticas tblDieteticas)
        {
            if (ModelState.IsValid)
            {
                db.tblDieteticas.Add(tblDieteticas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDieteticas);
        }

        // GET: tblDieteticas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDieteticas tblDieteticas = db.tblDieteticas.Find(id);
            if (tblDieteticas == null)
            {
                return HttpNotFound();
            }
            return View(tblDieteticas);
        }

        // POST: tblDieteticas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDietetica,nomDietetica")] tblDieteticas tblDieteticas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDieteticas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDieteticas);
        }

        // GET: tblDieteticas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDieteticas tblDieteticas = db.tblDieteticas.Find(id);
            if (tblDieteticas == null)
            {
                return HttpNotFound();
            }
            return View(tblDieteticas);
        }

        // POST: tblDieteticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDieteticas tblDieteticas = db.tblDieteticas.Find(id);
            db.tblDieteticas.Remove(tblDieteticas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
