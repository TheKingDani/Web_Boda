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
    public class tblAcompanantesController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblAcompanantes
        public ActionResult Index()
        {
            var tblAcompanantes = db.tblAcompanantes.Include(t => t.tblInvitados);
            return View(tblAcompanantes.ToList());
        }

        // GET: tblAcompanantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAcompanantes tblAcompanantes = db.tblAcompanantes.Find(id);
            if (tblAcompanantes == null)
            {
                return HttpNotFound();
            }
            return View(tblAcompanantes);
        }

        // GET: tblAcompanantes/Create
        public ActionResult Create()
        {
            ViewBag.idInvitado = new SelectList(db.tblInvitados, "idInvitado", "apodo");
            return View();
        }

        // POST: tblAcompanantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAcompanate,idInvitado,acompanante,confirmado,mesa")] tblAcompanantes tblAcompanantes)
        {
            if (ModelState.IsValid)
            {
                db.tblAcompanantes.Add(tblAcompanantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idInvitado = new SelectList(db.tblInvitados, "idInvitado", "apodo", tblAcompanantes.idInvitado);
            return View(tblAcompanantes);
        }

        // GET: tblAcompanantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAcompanantes tblAcompanantes = db.tblAcompanantes.Find(id);
            if (tblAcompanantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.idInvitado = new SelectList(db.tblInvitados, "idInvitado", "apodo", tblAcompanantes.idInvitado);
            return View(tblAcompanantes);
        }

        // POST: tblAcompanantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAcompanate,idInvitado,acompanante,confirmado,mesa")] tblAcompanantes tblAcompanantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAcompanantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idInvitado = new SelectList(db.tblInvitados, "idInvitado", "apodo", tblAcompanantes.idInvitado);
            return View(tblAcompanantes);
        }

        // GET: tblAcompanantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAcompanantes tblAcompanantes = db.tblAcompanantes.Find(id);
            if (tblAcompanantes == null)
            {
                return HttpNotFound();
            }
            return View(tblAcompanantes);
        }

        // POST: tblAcompanantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAcompanantes tblAcompanantes = db.tblAcompanantes.Find(id);
            db.tblAcompanantes.Remove(tblAcompanantes);
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
