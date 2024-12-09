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
    public class tblPresupuestosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblPresupuestos
        public ActionResult Index()
        {
            var tblPresupuestos = db.tblPresupuestos.Include(t => t.tblNovios).Include(t => t.tblProductosProveedores).Include(t => t.tblServiciosProveedores).Include(t => t.tblServiciosCategoriasProvedores).Include(t => t.tblStatusPagos);
            return View(tblPresupuestos.ToList());
        }

        // GET: tblPresupuestos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPresupuestos tblPresupuestos = db.tblPresupuestos.Find(id);
            if (tblPresupuestos == null)
            {
                return HttpNotFound();
            }
            return View(tblPresupuestos);
        }

        // GET: tblPresupuestos/Create
        public ActionResult Create()
        {
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            ViewBag.idProductoProveedor = new SelectList(db.tblProductosProveedores, "idProductoProveedor", "nombreProducto");
            ViewBag.idServicioCategoProv = new SelectList(db.tblServiciosProveedores, "idServicioProveedor", "idServicioProveedor");
            ViewBag.idServicioCategoProv = new SelectList(db.tblServiciosCategoriasProvedores, "idServicioCategoProv", "serviciosProveedores");
            ViewBag.idStatusPago = new SelectList(db.tblStatusPagos, "idStatusPago", "nomStatus");
            return View();
        }

        // POST: tblPresupuestos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPresupuesto,idNovios,idServicioCategoProv,costo,fechaPago,idStatusPago,descripcion,observaciones,idProductoProveedor")] tblPresupuestos tblPresupuestos)
        {
            if (ModelState.IsValid)
            {
                db.tblPresupuestos.Add(tblPresupuestos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblPresupuestos.idNovios);
            ViewBag.idProductoProveedor = new SelectList(db.tblProductosProveedores, "idProductoProveedor", "nombreProducto", tblPresupuestos.idProductoProveedor);
            ViewBag.idServicioCategoProv = new SelectList(db.tblServiciosProveedores, "idServicioProveedor", "idServicioProveedor", tblPresupuestos.idServicioCategoProv);
            ViewBag.idServicioCategoProv = new SelectList(db.tblServiciosCategoriasProvedores, "idServicioCategoProv", "serviciosProveedores", tblPresupuestos.idServicioCategoProv);
            ViewBag.idStatusPago = new SelectList(db.tblStatusPagos, "idStatusPago", "nomStatus", tblPresupuestos.idStatusPago);
            return View(tblPresupuestos);
        }

        // GET: tblPresupuestos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPresupuestos tblPresupuestos = db.tblPresupuestos.Find(id);
            if (tblPresupuestos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblPresupuestos.idNovios);
            ViewBag.idProductoProveedor = new SelectList(db.tblProductosProveedores, "idProductoProveedor", "nombreProducto", tblPresupuestos.idProductoProveedor);
            ViewBag.idServicioCategoProv = new SelectList(db.tblServiciosProveedores, "idServicioProveedor", "idServicioProveedor", tblPresupuestos.idServicioCategoProv);
            ViewBag.idServicioCategoProv = new SelectList(db.tblServiciosCategoriasProvedores, "idServicioCategoProv", "serviciosProveedores", tblPresupuestos.idServicioCategoProv);
            ViewBag.idStatusPago = new SelectList(db.tblStatusPagos, "idStatusPago", "nomStatus", tblPresupuestos.idStatusPago);
            return View(tblPresupuestos);
        }

        // POST: tblPresupuestos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPresupuesto,idNovios,idServicioCategoProv,costo,fechaPago,idStatusPago,descripcion,observaciones,idProductoProveedor")] tblPresupuestos tblPresupuestos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPresupuestos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblPresupuestos.idNovios);
            ViewBag.idProductoProveedor = new SelectList(db.tblProductosProveedores, "idProductoProveedor", "nombreProducto", tblPresupuestos.idProductoProveedor);
            ViewBag.idServicioCategoProv = new SelectList(db.tblServiciosProveedores, "idServicioProveedor", "idServicioProveedor", tblPresupuestos.idServicioCategoProv);
            ViewBag.idServicioCategoProv = new SelectList(db.tblServiciosCategoriasProvedores, "idServicioCategoProv", "serviciosProveedores", tblPresupuestos.idServicioCategoProv);
            ViewBag.idStatusPago = new SelectList(db.tblStatusPagos, "idStatusPago", "nomStatus", tblPresupuestos.idStatusPago);
            return View(tblPresupuestos);
        }

        // GET: tblPresupuestos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPresupuestos tblPresupuestos = db.tblPresupuestos.Find(id);
            if (tblPresupuestos == null)
            {
                return HttpNotFound();
            }
            return View(tblPresupuestos);
        }

        // POST: tblPresupuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPresupuestos tblPresupuestos = db.tblPresupuestos.Find(id);
            db.tblPresupuestos.Remove(tblPresupuestos);
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
