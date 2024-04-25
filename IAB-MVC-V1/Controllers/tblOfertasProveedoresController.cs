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
    public class tblOfertasProveedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblOfertasProveedores
        public ActionResult Index()
        {
            return View(db.tblOfertasProveedores.ToList());
        }

        // GET: tblOfertasProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOfertasProveedores tblOfertasProveedores = db.tblOfertasProveedores.Find(id);
            if (tblOfertasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblOfertasProveedores);
        }

        // GET: tblOfertasProveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblOfertasProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOfertaProveedor,oferta,estatus")] tblOfertasProveedores tblOfertasProveedores)
        {
            if (ModelState.IsValid)
            {
                db.tblOfertasProveedores.Add(tblOfertasProveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblOfertasProveedores);
        }

        // GET: tblOfertasProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOfertasProveedores tblOfertasProveedores = db.tblOfertasProveedores.Find(id);
            if (tblOfertasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblOfertasProveedores);
        }

        // POST: tblOfertasProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOfertaProveedor,oferta,estatus")] tblOfertasProveedores tblOfertasProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOfertasProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblOfertasProveedores);
        }

        // GET: tblOfertasProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOfertasProveedores tblOfertasProveedores = db.tblOfertasProveedores.Find(id);
            if (tblOfertasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblOfertasProveedores);
        }

        // POST: tblOfertasProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOfertasProveedores tblOfertasProveedores = db.tblOfertasProveedores.Find(id);
            db.tblOfertasProveedores.Remove(tblOfertasProveedores);
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
