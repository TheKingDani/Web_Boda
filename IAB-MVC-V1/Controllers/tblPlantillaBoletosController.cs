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
    public class tblPlantillaBoletosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblPlantillaBoletos
        public ActionResult Index()
        {
            return View(db.tblPlantillaBoletos.ToList());
        }

        // GET: tblPlantillaBoletos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantillaBoletos tblPlantillaBoletos = db.tblPlantillaBoletos.Find(id);
            if (tblPlantillaBoletos == null)
            {
                return HttpNotFound();
            }
            return View(tblPlantillaBoletos);
        }

        // GET: tblPlantillaBoletos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblPlantillaBoletos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPM_boletos,plantillaBoleto,ancho,alto")] tblPlantillaBoletos tblPlantillaBoletos)
        {
            if (ModelState.IsValid)
            {
                db.tblPlantillaBoletos.Add(tblPlantillaBoletos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPlantillaBoletos);
        }

        // GET: tblPlantillaBoletos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantillaBoletos tblPlantillaBoletos = db.tblPlantillaBoletos.Find(id);
            if (tblPlantillaBoletos == null)
            {
                return HttpNotFound();
            }
            return View(tblPlantillaBoletos);
        }

        // POST: tblPlantillaBoletos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPM_boletos,plantillaBoleto,ancho,alto")] tblPlantillaBoletos tblPlantillaBoletos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPlantillaBoletos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPlantillaBoletos);
        }

        // GET: tblPlantillaBoletos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantillaBoletos tblPlantillaBoletos = db.tblPlantillaBoletos.Find(id);
            if (tblPlantillaBoletos == null)
            {
                return HttpNotFound();
            }
            return View(tblPlantillaBoletos);
        }

        // POST: tblPlantillaBoletos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPlantillaBoletos tblPlantillaBoletos = db.tblPlantillaBoletos.Find(id);
            db.tblPlantillaBoletos.Remove(tblPlantillaBoletos);
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
