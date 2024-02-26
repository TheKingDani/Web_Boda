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
    public class tblWPNoviosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblWPNovios
        public ActionResult Index()
        {
            var tblWPNovios = db.tblWPNovios.Include(t => t.tblWeddingPlanners).Include(t => t.tblNovios);
            return View(tblWPNovios.ToList());
        }

        // GET: tblWPNovios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWPNovios tblWPNovios = db.tblWPNovios.Find(id);
            if (tblWPNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblWPNovios);
        }

        // GET: tblWPNovios/Create
        public ActionResult Create()
        {
            ViewBag.idWeddingPlanner = new SelectList(db.tblWeddingPlanners, "idWeddingPlanner", "nombre");
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblWPNovios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idWPNovios,idWeddingPlanner,idNovios")] tblWPNovios tblWPNovios)
        {
            if (ModelState.IsValid)
            {
                db.tblWPNovios.Add(tblWPNovios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idWeddingPlanner = new SelectList(db.tblWeddingPlanners, "idWeddingPlanner", "nombre", tblWPNovios.idWeddingPlanner);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblWPNovios.idNovios);
            return View(tblWPNovios);
        }

        // GET: tblWPNovios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWPNovios tblWPNovios = db.tblWPNovios.Find(id);
            if (tblWPNovios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idWeddingPlanner = new SelectList(db.tblWeddingPlanners, "idWeddingPlanner", "nombre", tblWPNovios.idWeddingPlanner);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblWPNovios.idNovios);
            return View(tblWPNovios);
        }

        // POST: tblWPNovios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idWPNovios,idWeddingPlanner,idNovios")] tblWPNovios tblWPNovios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblWPNovios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idWeddingPlanner = new SelectList(db.tblWeddingPlanners, "idWeddingPlanner", "nombre", tblWPNovios.idWeddingPlanner);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblWPNovios.idNovios);
            return View(tblWPNovios);
        }

        // GET: tblWPNovios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWPNovios tblWPNovios = db.tblWPNovios.Find(id);
            if (tblWPNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblWPNovios);
        }

        // POST: tblWPNovios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblWPNovios tblWPNovios = db.tblWPNovios.Find(id);
            db.tblWPNovios.Remove(tblWPNovios);
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
