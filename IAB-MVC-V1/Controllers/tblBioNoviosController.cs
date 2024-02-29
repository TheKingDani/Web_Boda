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
    public class tblBioNoviosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblBioNovios
        public ActionResult Index()
        {
            var tblBioNovios = db.tblBioNovios.Include(t => t.tblNovios);
            return View(tblBioNovios.ToList());
        }

        // GET: tblBioNovios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBioNovios tblBioNovios = db.tblBioNovios.Find(id);
            if (tblBioNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblBioNovios);
        }

        // GET: tblBioNovios/Create
        public ActionResult Create()
        {
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblBioNovios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBioNovio,idGenero,biografia,idNovios")] tblBioNovios tblBioNovios)
        {
            if (ModelState.IsValid)
            {
                db.tblBioNovios.Add(tblBioNovios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblBioNovios.idNovios);
            return View(tblBioNovios);
        }

        // GET: tblBioNovios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBioNovios tblBioNovios = db.tblBioNovios.Find(id);
            if (tblBioNovios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblBioNovios.idNovios);
            return View(tblBioNovios);
        }

        // POST: tblBioNovios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBioNovio,idGenero,biografia,idNovios")] tblBioNovios tblBioNovios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBioNovios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblBioNovios.idNovios);
            return View(tblBioNovios);
        }

        // GET: tblBioNovios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBioNovios tblBioNovios = db.tblBioNovios.Find(id);
            if (tblBioNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblBioNovios);
        }

        // POST: tblBioNovios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBioNovios tblBioNovios = db.tblBioNovios.Find(id);
            db.tblBioNovios.Remove(tblBioNovios);
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
