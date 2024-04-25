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
    public class tblServiciosProveedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblServiciosProveedores
        public ActionResult Index()
        {
            var tblServiciosProveedores = db.tblServiciosProveedores.Include(t => t.tblProveedores).Include(t => t.tblServiciosCategoriasProvedores);
            return View(tblServiciosProveedores.ToList());
        }

        // GET: tblServiciosProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblServiciosProveedores tblServiciosProveedores = db.tblServiciosProveedores.Find(id);
            if (tblServiciosProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblServiciosProveedores);
        }

        // GET: tblServiciosProveedores/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio");
            ViewBag.idServiciosCategoProv = new SelectList(db.tblServiciosCategoriasProvedores, "idServicioCategoProv", "serviciosProveedores");
            return View();
        }

        // POST: tblServiciosProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServicioProveedor,idProveedor,idServiciosCategoProv")] tblServiciosProveedores tblServiciosProveedores)
        {
            if (ModelState.IsValid)
            {
                db.tblServiciosProveedores.Add(tblServiciosProveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblServiciosProveedores.idProveedor);
            ViewBag.idServiciosCategoProv = new SelectList(db.tblServiciosCategoriasProvedores, "idServicioCategoProv", "serviciosProveedores", tblServiciosProveedores.idServiciosCategoProv);
            return View(tblServiciosProveedores);
        }

        // GET: tblServiciosProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblServiciosProveedores tblServiciosProveedores = db.tblServiciosProveedores.Find(id);
            if (tblServiciosProveedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblServiciosProveedores.idProveedor);
            ViewBag.idServiciosCategoProv = new SelectList(db.tblServiciosCategoriasProvedores, "idServicioCategoProv", "serviciosProveedores", tblServiciosProveedores.idServiciosCategoProv);
            return View(tblServiciosProveedores);
        }

        // POST: tblServiciosProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServicioProveedor,idProveedor,idServiciosCategoProv")] tblServiciosProveedores tblServiciosProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblServiciosProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblServiciosProveedores.idProveedor);
            ViewBag.idServiciosCategoProv = new SelectList(db.tblServiciosCategoriasProvedores, "idServicioCategoProv", "serviciosProveedores", tblServiciosProveedores.idServiciosCategoProv);
            return View(tblServiciosProveedores);
        }

        // GET: tblServiciosProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblServiciosProveedores tblServiciosProveedores = db.tblServiciosProveedores.Find(id);
            if (tblServiciosProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblServiciosProveedores);
        }

        // POST: tblServiciosProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblServiciosProveedores tblServiciosProveedores = db.tblServiciosProveedores.Find(id);
            db.tblServiciosProveedores.Remove(tblServiciosProveedores);
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
