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
    public class tblWeddingPlannersController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblWeddingPlanners
        public ActionResult Index()
        {
            var tblWeddingPlanners = db.tblWeddingPlanners.Include(t => t.tblEmpresas);
            return View(tblWeddingPlanners.ToList());
        }

        // GET: tblWeddingPlanners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWeddingPlanners tblWeddingPlanners = db.tblWeddingPlanners.Find(id);
            if (tblWeddingPlanners == null)
            {
                return HttpNotFound();
            }
            return View(tblWeddingPlanners);
        }

        // GET: tblWeddingPlanners/Create
        public ActionResult Create()
        {
            ViewBag.idEmpresa = new SelectList(db.tblEmpresas, "idEmpresa", "nombreEmpresa");
            return View();
        }

        // POST: tblWeddingPlanners/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idWeddingPlanner,nombre,apellidoPaterno,apellidoMaterno,correoElectronico1,correoElectronico2,telefono,usuario,contraseña,activo,idEmpresa")] tblWeddingPlanners tblWeddingPlanners)
        {
            if (ModelState.IsValid)
            {
                db.tblWeddingPlanners.Add(tblWeddingPlanners);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpresa = new SelectList(db.tblEmpresas, "idEmpresa", "nombreEmpresa", tblWeddingPlanners.idEmpresa);
            return View(tblWeddingPlanners);
        }

        // GET: tblWeddingPlanners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWeddingPlanners tblWeddingPlanners = db.tblWeddingPlanners.Find(id);
            if (tblWeddingPlanners == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpresa = new SelectList(db.tblEmpresas, "idEmpresa", "nombreEmpresa", tblWeddingPlanners.idEmpresa);
            return View(tblWeddingPlanners);
        }

        // POST: tblWeddingPlanners/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idWeddingPlanner,nombre,apellidoPaterno,apellidoMaterno,correoElectronico1,correoElectronico2,telefono,usuario,contraseña,activo,idEmpresa")] tblWeddingPlanners tblWeddingPlanners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblWeddingPlanners).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpresa = new SelectList(db.tblEmpresas, "idEmpresa", "nombreEmpresa", tblWeddingPlanners.idEmpresa);
            return View(tblWeddingPlanners);
        }

        // GET: tblWeddingPlanners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWeddingPlanners tblWeddingPlanners = db.tblWeddingPlanners.Find(id);
            if (tblWeddingPlanners == null)
            {
                return HttpNotFound();
            }
            return View(tblWeddingPlanners);
        }

        // POST: tblWeddingPlanners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblWeddingPlanners tblWeddingPlanners = db.tblWeddingPlanners.Find(id);
            db.tblWeddingPlanners.Remove(tblWeddingPlanners);
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
