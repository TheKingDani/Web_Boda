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
    public class tblBebidasNoviosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblBebidasNovios
        public ActionResult Index()
        {
            var tblBebidasNovios = db.tblBebidasNovios.Include(t => t.tblBebidas).Include(t => t.tblNovios);
            return View(tblBebidasNovios.ToList());
        }

        // GET: tblBebidasNovios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBebidasNovios tblBebidasNovios = db.tblBebidasNovios.Find(id);
            if (tblBebidasNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblBebidasNovios);
        }

        // GET: tblBebidasNovios/Create
        public ActionResult Create()
        {
            ViewBag.idBebida = new SelectList(db.tblBebidas, "idBebida", "bebida");
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblBebidasNovios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBebidaNovios,idBebida,idNovios")] tblBebidasNovios tblBebidasNovios)
        {
            if (ModelState.IsValid)
            {
                db.tblBebidasNovios.Add(tblBebidasNovios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBebida = new SelectList(db.tblBebidas, "idBebida", "bebida", tblBebidasNovios.idBebida);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblBebidasNovios.idNovios);
            return View(tblBebidasNovios);
        }

        // GET: tblBebidasNovios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBebidasNovios tblBebidasNovios = db.tblBebidasNovios.Find(id);
            if (tblBebidasNovios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBebida = new SelectList(db.tblBebidas, "idBebida", "bebida", tblBebidasNovios.idBebida);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblBebidasNovios.idNovios);
            return View(tblBebidasNovios);
        }

        // POST: tblBebidasNovios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBebidaNovios,idBebida,idNovios")] tblBebidasNovios tblBebidasNovios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBebidasNovios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBebida = new SelectList(db.tblBebidas, "idBebida", "bebida", tblBebidasNovios.idBebida);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblBebidasNovios.idNovios);
            return View(tblBebidasNovios);
        }

        // GET: tblBebidasNovios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBebidasNovios tblBebidasNovios = db.tblBebidasNovios.Find(id);
            if (tblBebidasNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblBebidasNovios);
        }

        // POST: tblBebidasNovios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBebidasNovios tblBebidasNovios = db.tblBebidasNovios.Find(id);
            db.tblBebidasNovios.Remove(tblBebidasNovios);
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
