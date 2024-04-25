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
    public class tblRedesSocialesController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblRedesSociales
        public ActionResult Index()
        {
            return View(db.tblRedesSociales.ToList());
        }

        // GET: tblRedesSociales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRedesSociales tblRedesSociales = db.tblRedesSociales.Find(id);
            if (tblRedesSociales == null)
            {
                return HttpNotFound();
            }
            return View(tblRedesSociales);
        }

        // GET: tblRedesSociales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblRedesSociales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRedSocial,redSocial,estatus")] tblRedesSociales tblRedesSociales)
        {
            if (ModelState.IsValid)
            {
                db.tblRedesSociales.Add(tblRedesSociales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblRedesSociales);
        }

        // GET: tblRedesSociales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRedesSociales tblRedesSociales = db.tblRedesSociales.Find(id);
            if (tblRedesSociales == null)
            {
                return HttpNotFound();
            }
            return View(tblRedesSociales);
        }

        // POST: tblRedesSociales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRedSocial,redSocial,estatus")] tblRedesSociales tblRedesSociales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRedesSociales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblRedesSociales);
        }

        // GET: tblRedesSociales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRedesSociales tblRedesSociales = db.tblRedesSociales.Find(id);
            if (tblRedesSociales == null)
            {
                return HttpNotFound();
            }
            return View(tblRedesSociales);
        }

        // POST: tblRedesSociales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRedesSociales tblRedesSociales = db.tblRedesSociales.Find(id);
            db.tblRedesSociales.Remove(tblRedesSociales);
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
