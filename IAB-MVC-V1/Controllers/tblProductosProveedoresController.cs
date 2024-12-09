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
    public class tblProductosProveedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblProductosProveedores
        public ActionResult Index()
        {
            var tblProductosProveedores = db.tblProductosProveedores.Include(t => t.tblServiciosProveedores);
            return View(tblProductosProveedores.ToList());
        }

        // GET: tblProductosProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductosProveedores tblProductosProveedores = db.tblProductosProveedores.Find(id);
            if (tblProductosProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblProductosProveedores);
        }

        // GET: tblProductosProveedores/Create
        public ActionResult Create()
        {
            ViewBag.idServicioProveedor = new SelectList(db.tblServiciosProveedores, "idServicioProveedor", "idServicioProveedor");
            return View();
        }

        // POST: tblProductosProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProductoProveedor,idServicioProveedor,nombreProducto,precioProducto,descripcion")] tblProductosProveedores tblProductosProveedores)
        {
            if (ModelState.IsValid)
            {
                db.tblProductosProveedores.Add(tblProductosProveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idServicioProveedor = new SelectList(db.tblServiciosProveedores, "idServicioProveedor", "idServicioProveedor", tblProductosProveedores.idServicioProveedor);
            return View(tblProductosProveedores);
        }

        // GET: tblProductosProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductosProveedores tblProductosProveedores = db.tblProductosProveedores.Find(id);
            if (tblProductosProveedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idServicioProveedor = new SelectList(db.tblServiciosProveedores, "idServicioProveedor", "idServicioProveedor", tblProductosProveedores.idServicioProveedor);
            return View(tblProductosProveedores);
        }

        // POST: tblProductosProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProductoProveedor,idServicioProveedor,nombreProducto,precioProducto,descripcion")] tblProductosProveedores tblProductosProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProductosProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idServicioProveedor = new SelectList(db.tblServiciosProveedores, "idServicioProveedor", "idServicioProveedor", tblProductosProveedores.idServicioProveedor);
            return View(tblProductosProveedores);
        }

        // GET: tblProductosProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductosProveedores tblProductosProveedores = db.tblProductosProveedores.Find(id);
            if (tblProductosProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblProductosProveedores);
        }

        // POST: tblProductosProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProductosProveedores tblProductosProveedores = db.tblProductosProveedores.Find(id);
            db.tblProductosProveedores.Remove(tblProductosProveedores);
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
