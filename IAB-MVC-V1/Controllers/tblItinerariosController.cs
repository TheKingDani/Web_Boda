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
    public class tblItinerariosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblItinerarios
        public ActionResult Index()
        {
            var tblItinerarios = db.tblItinerarios.Include(t => t.tblNovios);
            return View(tblItinerarios.ToList());
        }

        // GET: tblItinerarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItinerarios tblItinerarios = db.tblItinerarios.Find(id);
            if (tblItinerarios == null)
            {
                return HttpNotFound();
            }
            return View(tblItinerarios);
        }

        // GET: tblItinerarios/Create
        public ActionResult Create()
        {
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblItinerarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idItinerario,idNovios,horaInicio,horaFin,actividad,responsables")] tblItinerarios tblItinerarios)
        {
            if (ModelState.IsValid)
            {
                db.tblItinerarios.Add(tblItinerarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblItinerarios.idNovios);
            return View(tblItinerarios);
        }

        // GET: tblItinerarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItinerarios tblItinerarios = db.tblItinerarios.Find(id);
            if (tblItinerarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblItinerarios.idNovios);
            return View(tblItinerarios);
        }

        // POST: tblItinerarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idItinerario,idNovios,horaInicio,horaFin,actividad,responsables")] tblItinerarios tblItinerarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblItinerarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblItinerarios.idNovios);
            return View(tblItinerarios);
        }

        // GET: tblItinerarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItinerarios tblItinerarios = db.tblItinerarios.Find(id);
            if (tblItinerarios == null)
            {
                return HttpNotFound();
            }
            return View(tblItinerarios);
        }

        // POST: tblItinerarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblItinerarios tblItinerarios = db.tblItinerarios.Find(id);
            db.tblItinerarios.Remove(tblItinerarios);
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
