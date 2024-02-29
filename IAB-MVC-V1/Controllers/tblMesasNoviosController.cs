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
    public class tblMesasNoviosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblMesasNovios
        public ActionResult Index()
        {
            var tblMesasNovios = db.tblMesasNovios.Include(t => t.tblMesasRegalos).Include(t => t.tblNovios);
            return View(tblMesasNovios.ToList());
        }

        // GET: tblMesasNovios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMesasNovios tblMesasNovios = db.tblMesasNovios.Find(id);
            if (tblMesasNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblMesasNovios);
        }

        // GET: tblMesasNovios/Create
        public ActionResult Create()
        {
            ViewBag.idMesaRegalo = new SelectList(db.tblMesasRegalos, "idMesaRegalo", "nombre");
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblMesasNovios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMesaNovio,idMesaRegalo,numero,idNovios")] tblMesasNovios tblMesasNovios)
        {
            if (ModelState.IsValid)
            {
                db.tblMesasNovios.Add(tblMesasNovios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMesaRegalo = new SelectList(db.tblMesasRegalos, "idMesaRegalo", "nombre", tblMesasNovios.idMesaRegalo);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblMesasNovios.idNovios);
            return View(tblMesasNovios);
        }

        // GET: tblMesasNovios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMesasNovios tblMesasNovios = db.tblMesasNovios.Find(id);
            if (tblMesasNovios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMesaRegalo = new SelectList(db.tblMesasRegalos, "idMesaRegalo", "nombre", tblMesasNovios.idMesaRegalo);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblMesasNovios.idNovios);
            return View(tblMesasNovios);
        }

        // POST: tblMesasNovios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMesaNovio,idMesaRegalo,numero,idNovios")] tblMesasNovios tblMesasNovios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMesasNovios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMesaRegalo = new SelectList(db.tblMesasRegalos, "idMesaRegalo", "nombre", tblMesasNovios.idMesaRegalo);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblMesasNovios.idNovios);
            return View(tblMesasNovios);
        }

        // GET: tblMesasNovios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMesasNovios tblMesasNovios = db.tblMesasNovios.Find(id);
            if (tblMesasNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblMesasNovios);
        }

        // POST: tblMesasNovios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMesasNovios tblMesasNovios = db.tblMesasNovios.Find(id);
            db.tblMesasNovios.Remove(tblMesasNovios);
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
