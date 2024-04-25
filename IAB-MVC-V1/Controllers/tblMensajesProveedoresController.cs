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
    public class tblMensajesProveedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblMensajesProveedores
        public ActionResult Index()
        {
            var tblMensajesProveedores = db.tblMensajesProveedores.Include(t => t.tblProveedores);
            return View(tblMensajesProveedores.ToList());
        }

        // GET: tblMensajesProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMensajesProveedores tblMensajesProveedores = db.tblMensajesProveedores.Find(id);
            if (tblMensajesProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblMensajesProveedores);
        }

        // GET: tblMensajesProveedores/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio");
            return View();
        }

        // POST: tblMensajesProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMensajeProveedor,idProveedor,tituloMensaje,Mensaje")] tblMensajesProveedores tblMensajesProveedores)
        {
            if (ModelState.IsValid)
            {
                db.tblMensajesProveedores.Add(tblMensajesProveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblMensajesProveedores.idProveedor);
            return View(tblMensajesProveedores);
        }

        // GET: tblMensajesProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMensajesProveedores tblMensajesProveedores = db.tblMensajesProveedores.Find(id);
            if (tblMensajesProveedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblMensajesProveedores.idProveedor);
            return View(tblMensajesProveedores);
        }

        // POST: tblMensajesProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMensajeProveedor,idProveedor,tituloMensaje,Mensaje")] tblMensajesProveedores tblMensajesProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMensajesProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblMensajesProveedores.idProveedor);
            return View(tblMensajesProveedores);
        }

        // GET: tblMensajesProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMensajesProveedores tblMensajesProveedores = db.tblMensajesProveedores.Find(id);
            if (tblMensajesProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblMensajesProveedores);
        }

        // POST: tblMensajesProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMensajesProveedores tblMensajesProveedores = db.tblMensajesProveedores.Find(id);
            db.tblMensajesProveedores.Remove(tblMensajesProveedores);
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
