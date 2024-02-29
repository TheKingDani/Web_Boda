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
    public class tblIntentosIngresoesController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblIntentosIngresoes
        public ActionResult Index()
        {
            return View(db.tblIntentosIngreso.ToList());
        }

        // GET: tblIntentosIngresoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIntentosIngreso tblIntentosIngreso = db.tblIntentosIngreso.Find(id);
            if (tblIntentosIngreso == null)
            {
                return HttpNotFound();
            }
            return View(tblIntentosIngreso);
        }

        // GET: tblIntentosIngresoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblIntentosIngresoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idIntentoIngreso,usuario,pass,fechaHora,ingreso")] tblIntentosIngreso tblIntentosIngreso)
        {
            if (ModelState.IsValid)
            {
                db.tblIntentosIngreso.Add(tblIntentosIngreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblIntentosIngreso);
        }

        // GET: tblIntentosIngresoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIntentosIngreso tblIntentosIngreso = db.tblIntentosIngreso.Find(id);
            if (tblIntentosIngreso == null)
            {
                return HttpNotFound();
            }
            return View(tblIntentosIngreso);
        }

        // POST: tblIntentosIngresoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idIntentoIngreso,usuario,pass,fechaHora,ingreso")] tblIntentosIngreso tblIntentosIngreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblIntentosIngreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblIntentosIngreso);
        }

        // GET: tblIntentosIngresoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIntentosIngreso tblIntentosIngreso = db.tblIntentosIngreso.Find(id);
            if (tblIntentosIngreso == null)
            {
                return HttpNotFound();
            }
            return View(tblIntentosIngreso);
        }

        // POST: tblIntentosIngresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblIntentosIngreso tblIntentosIngreso = db.tblIntentosIngreso.Find(id);
            db.tblIntentosIngreso.Remove(tblIntentosIngreso);
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
