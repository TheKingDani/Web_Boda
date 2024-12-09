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
    public class tblStatusPagosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblStatusPagos
        public ActionResult Index()
        {
            return View(db.tblStatusPagos.ToList());
        }

        // GET: tblStatusPagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatusPagos tblStatusPagos = db.tblStatusPagos.Find(id);
            if (tblStatusPagos == null)
            {
                return HttpNotFound();
            }
            return View(tblStatusPagos);
        }

        // GET: tblStatusPagos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblStatusPagos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStatusPago,nomStatus")] tblStatusPagos tblStatusPagos)
        {
            if (ModelState.IsValid)
            {
                db.tblStatusPagos.Add(tblStatusPagos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblStatusPagos);
        }

        // GET: tblStatusPagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatusPagos tblStatusPagos = db.tblStatusPagos.Find(id);
            if (tblStatusPagos == null)
            {
                return HttpNotFound();
            }
            return View(tblStatusPagos);
        }

        // POST: tblStatusPagos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStatusPago,nomStatus")] tblStatusPagos tblStatusPagos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStatusPagos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblStatusPagos);
        }

        // GET: tblStatusPagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatusPagos tblStatusPagos = db.tblStatusPagos.Find(id);
            if (tblStatusPagos == null)
            {
                return HttpNotFound();
            }
            return View(tblStatusPagos);
        }

        // POST: tblStatusPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStatusPagos tblStatusPagos = db.tblStatusPagos.Find(id);
            db.tblStatusPagos.Remove(tblStatusPagos);
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
