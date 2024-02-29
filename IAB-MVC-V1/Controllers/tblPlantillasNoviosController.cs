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
    public class tblPlantillasNoviosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblPlantillasNovios
        public ActionResult Index()
        {
            var tblPlantillasNovios = db.tblPlantillasNovios.Include(t => t.tblNovios);
            return View(tblPlantillasNovios.ToList());
        }

        // GET: tblPlantillasNovios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantillasNovios tblPlantillasNovios = db.tblPlantillasNovios.Find(id);
            if (tblPlantillasNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblPlantillasNovios);
        }

        // GET: tblPlantillasNovios/Create
        public ActionResult Create()
        {
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblPlantillasNovios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPlantillasNovios,idNovios,idPM_invitacion,idPW_invitacion,idPWA_invitacion,idPM_boletos,idPWA_boletos,idPM_urgente,idPWA_urgente,idPM_diaD,idPWA_diaD")] tblPlantillasNovios tblPlantillasNovios)
        {
            if (ModelState.IsValid)
            {
                db.tblPlantillasNovios.Add(tblPlantillasNovios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblPlantillasNovios.idNovios);
            return View(tblPlantillasNovios);
        }

        // GET: tblPlantillasNovios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantillasNovios tblPlantillasNovios = db.tblPlantillasNovios.Find(id);
            if (tblPlantillasNovios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblPlantillasNovios.idNovios);
            return View(tblPlantillasNovios);
        }

        // POST: tblPlantillasNovios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPlantillasNovios,idNovios,idPM_invitacion,idPW_invitacion,idPWA_invitacion,idPM_boletos,idPWA_boletos,idPM_urgente,idPWA_urgente,idPM_diaD,idPWA_diaD")] tblPlantillasNovios tblPlantillasNovios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPlantillasNovios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblPlantillasNovios.idNovios);
            return View(tblPlantillasNovios);
        }

        // GET: tblPlantillasNovios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantillasNovios tblPlantillasNovios = db.tblPlantillasNovios.Find(id);
            if (tblPlantillasNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblPlantillasNovios);
        }

        // POST: tblPlantillasNovios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPlantillasNovios tblPlantillasNovios = db.tblPlantillasNovios.Find(id);
            db.tblPlantillasNovios.Remove(tblPlantillasNovios);
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
