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
    public class tblIdiomasController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblIdiomas
        public ActionResult Index()
        {
            return View(db.tblIdioma.ToList());
        }

        // GET: tblIdiomas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIdioma tblIdioma = db.tblIdioma.Find(id);
            if (tblIdioma == null)
            {
                return HttpNotFound();
            }
            return View(tblIdioma);
        }

        // GET: tblIdiomas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblIdiomas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idIdioma,idioma")] tblIdioma tblIdioma)
        {
            if (ModelState.IsValid)
            {
                db.tblIdioma.Add(tblIdioma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblIdioma);
        }

        // GET: tblIdiomas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIdioma tblIdioma = db.tblIdioma.Find(id);
            if (tblIdioma == null)
            {
                return HttpNotFound();
            }
            return View(tblIdioma);
        }

        // POST: tblIdiomas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idIdioma,idioma")] tblIdioma tblIdioma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblIdioma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblIdioma);
        }

        // GET: tblIdiomas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIdioma tblIdioma = db.tblIdioma.Find(id);
            if (tblIdioma == null)
            {
                return HttpNotFound();
            }
            return View(tblIdioma);
        }

        // POST: tblIdiomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblIdioma tblIdioma = db.tblIdioma.Find(id);
            db.tblIdioma.Remove(tblIdioma);
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
