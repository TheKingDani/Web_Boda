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
    public class tblEstadosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblEstados
        public ActionResult Index()
        {
            return View(db.tblEstados.ToList());
        }

        // GET: tblEstados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstados tblEstados = db.tblEstados.Find(id);
            if (tblEstados == null)
            {
                return HttpNotFound();
            }
            return View(tblEstados);
        }

        // GET: tblEstados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblEstados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstado,nombreEstado")] tblEstados tblEstados)
        {
            if (ModelState.IsValid)
            {
                db.tblEstados.Add(tblEstados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEstados);
        }

        // GET: tblEstados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstados tblEstados = db.tblEstados.Find(id);
            if (tblEstados == null)
            {
                return HttpNotFound();
            }
            return View(tblEstados);
        }

        // POST: tblEstados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstado,nombreEstado")] tblEstados tblEstados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEstados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEstados);
        }

        // GET: tblEstados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstados tblEstados = db.tblEstados.Find(id);
            if (tblEstados == null)
            {
                return HttpNotFound();
            }
            return View(tblEstados);
        }

        // POST: tblEstados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEstados tblEstados = db.tblEstados.Find(id);
            db.tblEstados.Remove(tblEstados);
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
