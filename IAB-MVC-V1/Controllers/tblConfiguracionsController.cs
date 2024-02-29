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
    public class tblConfiguracionsController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblConfiguracions
        public ActionResult Index()
        {
            var tblConfiguracion = db.tblConfiguracion.Include(t => t.tblNovios);
            return View(tblConfiguracion.ToList());
        }

        // GET: tblConfiguracions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblConfiguracion tblConfiguracion = db.tblConfiguracion.Find(id);
            if (tblConfiguracion == null)
            {
                return HttpNotFound();
            }
            return View(tblConfiguracion);
        }

        // GET: tblConfiguracions/Create
        public ActionResult Create()
        {
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblConfiguracions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idConfiguracion,idNovios,requiereAutenticacion,dominioExterno")] tblConfiguracion tblConfiguracion)
        {
            if (ModelState.IsValid)
            {
                db.tblConfiguracion.Add(tblConfiguracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblConfiguracion.idNovios);
            return View(tblConfiguracion);
        }

        // GET: tblConfiguracions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblConfiguracion tblConfiguracion = db.tblConfiguracion.Find(id);
            if (tblConfiguracion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblConfiguracion.idNovios);
            return View(tblConfiguracion);
        }

        // POST: tblConfiguracions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idConfiguracion,idNovios,requiereAutenticacion,dominioExterno")] tblConfiguracion tblConfiguracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblConfiguracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblConfiguracion.idNovios);
            return View(tblConfiguracion);
        }

        // GET: tblConfiguracions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblConfiguracion tblConfiguracion = db.tblConfiguracion.Find(id);
            if (tblConfiguracion == null)
            {
                return HttpNotFound();
            }
            return View(tblConfiguracion);
        }

        // POST: tblConfiguracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblConfiguracion tblConfiguracion = db.tblConfiguracion.Find(id);
            db.tblConfiguracion.Remove(tblConfiguracion);
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
