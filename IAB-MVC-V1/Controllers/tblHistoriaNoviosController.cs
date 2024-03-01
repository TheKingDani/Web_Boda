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
    public class tblHistoriaNoviosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblHistoriaNovios
        public ActionResult Index()
        {
            var tblHistoriaNovios = db.tblHistoriaNovios.Include(t => t.tblNovios);
            return View(tblHistoriaNovios.ToList());
        }

        // GET: tblHistoriaNovios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHistoriaNovios tblHistoriaNovios = db.tblHistoriaNovios.Find(id);
            if (tblHistoriaNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblHistoriaNovios);
        }

        // GET: tblHistoriaNovios/Create
        public ActionResult Create()
        {
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblHistoriaNovios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idNoviosHistoria,fechaConocieron,conocieron,imgConocieron,idNovios,fechaPropuesta,propuesta,imgPropuesta,fechaPrimeraCita,primeraCita,imgPrimeraCita,fechaPedida,pedida,imgPedida,fechaNovios,novios,imgNovios")] tblHistoriaNovios tblHistoriaNovios)
        {
            if (ModelState.IsValid)
            {
                db.tblHistoriaNovios.Add(tblHistoriaNovios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblHistoriaNovios.idNovios);
            return View(tblHistoriaNovios);
        }

        // GET: tblHistoriaNovios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHistoriaNovios tblHistoriaNovios = db.tblHistoriaNovios.Find(id);
            if (tblHistoriaNovios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblHistoriaNovios.idNovios);
            return View(tblHistoriaNovios);
        }

        // POST: tblHistoriaNovios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idNoviosHistoria,fechaConocieron,conocieron,imgConocieron,idNovios,fechaPropuesta,propuesta,imgPropuesta,fechaPrimeraCita,primeraCita,imgPrimeraCita,fechaPedida,pedida,imgPedida,fechaNovios,novios,imgNovios")] tblHistoriaNovios tblHistoriaNovios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblHistoriaNovios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblHistoriaNovios.idNovios);
            return View(tblHistoriaNovios);
        }

        // GET: tblHistoriaNovios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHistoriaNovios tblHistoriaNovios = db.tblHistoriaNovios.Find(id);
            if (tblHistoriaNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblHistoriaNovios);
        }

        // POST: tblHistoriaNovios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblHistoriaNovios tblHistoriaNovios = db.tblHistoriaNovios.Find(id);
            db.tblHistoriaNovios.Remove(tblHistoriaNovios);
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
