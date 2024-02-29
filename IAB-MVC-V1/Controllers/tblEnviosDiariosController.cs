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
    public class tblEnviosDiariosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblEnviosDiarios
        public ActionResult Index()
        {
            return View(db.tblEnviosDiarios.ToList());
        }

        // GET: tblEnviosDiarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEnviosDiarios tblEnviosDiarios = db.tblEnviosDiarios.Find(id);
            if (tblEnviosDiarios == null)
            {
                return HttpNotFound();
            }
            return View(tblEnviosDiarios);
        }

        // GET: tblEnviosDiarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblEnviosDiarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEnvio,idCuenta,cantidad,fecha")] tblEnviosDiarios tblEnviosDiarios)
        {
            if (ModelState.IsValid)
            {
                db.tblEnviosDiarios.Add(tblEnviosDiarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEnviosDiarios);
        }

        // GET: tblEnviosDiarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEnviosDiarios tblEnviosDiarios = db.tblEnviosDiarios.Find(id);
            if (tblEnviosDiarios == null)
            {
                return HttpNotFound();
            }
            return View(tblEnviosDiarios);
        }

        // POST: tblEnviosDiarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEnvio,idCuenta,cantidad,fecha")] tblEnviosDiarios tblEnviosDiarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEnviosDiarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEnviosDiarios);
        }

        // GET: tblEnviosDiarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEnviosDiarios tblEnviosDiarios = db.tblEnviosDiarios.Find(id);
            if (tblEnviosDiarios == null)
            {
                return HttpNotFound();
            }
            return View(tblEnviosDiarios);
        }

        // POST: tblEnviosDiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEnviosDiarios tblEnviosDiarios = db.tblEnviosDiarios.Find(id);
            db.tblEnviosDiarios.Remove(tblEnviosDiarios);
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
