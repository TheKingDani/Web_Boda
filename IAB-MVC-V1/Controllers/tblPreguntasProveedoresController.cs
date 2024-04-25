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
    public class tblPreguntasProveedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblPreguntasProveedores
        public ActionResult Index()
        {
            return View(db.tblPreguntasProveedores.ToList());
        }

        // GET: tblPreguntasProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPreguntasProveedores tblPreguntasProveedores = db.tblPreguntasProveedores.Find(id);
            if (tblPreguntasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblPreguntasProveedores);
        }

        // GET: tblPreguntasProveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblPreguntasProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPreguntaProveedor,Pregunta")] tblPreguntasProveedores tblPreguntasProveedores)
        {
            if (ModelState.IsValid)
            {
                db.tblPreguntasProveedores.Add(tblPreguntasProveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPreguntasProveedores);
        }

        // GET: tblPreguntasProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPreguntasProveedores tblPreguntasProveedores = db.tblPreguntasProveedores.Find(id);
            if (tblPreguntasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblPreguntasProveedores);
        }

        // POST: tblPreguntasProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPreguntaProveedor,Pregunta")] tblPreguntasProveedores tblPreguntasProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPreguntasProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPreguntasProveedores);
        }

        // GET: tblPreguntasProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPreguntasProveedores tblPreguntasProveedores = db.tblPreguntasProveedores.Find(id);
            if (tblPreguntasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblPreguntasProveedores);
        }

        // POST: tblPreguntasProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPreguntasProveedores tblPreguntasProveedores = db.tblPreguntasProveedores.Find(id);
            db.tblPreguntasProveedores.Remove(tblPreguntasProveedores);
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
