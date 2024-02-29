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
            return View(db.tblItinerario.ToList());
        }

        // GET: tblItinerarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItinerario tblItinerario = db.tblItinerario.Find(id);
            if (tblItinerario == null)
            {
                return HttpNotFound();
            }
            return View(tblItinerario);
        }

        // GET: tblItinerarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblItinerarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idItinerario,idNovio,diaHora,actividad")] tblItinerario tblItinerario)
        {
            if (ModelState.IsValid)
            {
                db.tblItinerario.Add(tblItinerario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblItinerario);
        }

        // GET: tblItinerarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItinerario tblItinerario = db.tblItinerario.Find(id);
            if (tblItinerario == null)
            {
                return HttpNotFound();
            }
            return View(tblItinerario);
        }

        // POST: tblItinerarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idItinerario,idNovio,diaHora,actividad")] tblItinerario tblItinerario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblItinerario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblItinerario);
        }

        // GET: tblItinerarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItinerario tblItinerario = db.tblItinerario.Find(id);
            if (tblItinerario == null)
            {
                return HttpNotFound();
            }
            return View(tblItinerario);
        }

        // POST: tblItinerarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblItinerario tblItinerario = db.tblItinerario.Find(id);
            db.tblItinerario.Remove(tblItinerario);
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
