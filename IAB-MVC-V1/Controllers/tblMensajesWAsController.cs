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
    public class tblMensajesWAsController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblMensajesWAs
        public ActionResult Index()
        {
            return View(db.tblMensajesWA.ToList());
        }

        // GET: tblMensajesWAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMensajesWA tblMensajesWA = db.tblMensajesWA.Find(id);
            if (tblMensajesWA == null)
            {
                return HttpNotFound();
            }
            return View(tblMensajesWA);
        }

        // GET: tblMensajesWAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblMensajesWAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMensajeWA,idTipoInvitado,idIdioma,mensajeInicial,mensajeMesaRegalos,mensajeDiaD")] tblMensajesWA tblMensajesWA)
        {
            if (ModelState.IsValid)
            {
                db.tblMensajesWA.Add(tblMensajesWA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblMensajesWA);
        }

        // GET: tblMensajesWAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMensajesWA tblMensajesWA = db.tblMensajesWA.Find(id);
            if (tblMensajesWA == null)
            {
                return HttpNotFound();
            }
            return View(tblMensajesWA);
        }

        // POST: tblMensajesWAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMensajeWA,idTipoInvitado,idIdioma,mensajeInicial,mensajeMesaRegalos,mensajeDiaD")] tblMensajesWA tblMensajesWA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMensajesWA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblMensajesWA);
        }

        // GET: tblMensajesWAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMensajesWA tblMensajesWA = db.tblMensajesWA.Find(id);
            if (tblMensajesWA == null)
            {
                return HttpNotFound();
            }
            return View(tblMensajesWA);
        }

        // POST: tblMensajesWAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMensajesWA tblMensajesWA = db.tblMensajesWA.Find(id);
            db.tblMensajesWA.Remove(tblMensajesWA);
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
