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
    public class tblBebidasController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblBebidas
        public ActionResult Index()
        {
            return View(db.tblBebidas.ToList());
        }

        // GET: tblBebidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBebidas tblBebidas = db.tblBebidas.Find(id);
            if (tblBebidas == null)
            {
                return HttpNotFound();
            }
            return View(tblBebidas);
        }

        // GET: tblBebidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblBebidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBebida,bebida")] tblBebidas tblBebidas)
        {
            if (ModelState.IsValid)
            {
                db.tblBebidas.Add(tblBebidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblBebidas);
        }

        // GET: tblBebidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBebidas tblBebidas = db.tblBebidas.Find(id);
            if (tblBebidas == null)
            {
                return HttpNotFound();
            }
            return View(tblBebidas);
        }

        // POST: tblBebidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBebida,bebida")] tblBebidas tblBebidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBebidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblBebidas);
        }

        // GET: tblBebidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBebidas tblBebidas = db.tblBebidas.Find(id);
            if (tblBebidas == null)
            {
                return HttpNotFound();
            }
            return View(tblBebidas);
        }

        // POST: tblBebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBebidas tblBebidas = db.tblBebidas.Find(id);
            db.tblBebidas.Remove(tblBebidas);
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
