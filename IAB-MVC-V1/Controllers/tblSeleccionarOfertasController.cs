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
    public class tblSeleccionarOfertasController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblSeleccionarOfertas
        public ActionResult Index()
        {
            var tblSeleccionarOfertas = db.tblSeleccionarOfertas.Include(t => t.tblOfertasProveedores).Include(t => t.tblProveedores);
            return View(tblSeleccionarOfertas.ToList());
        }

        // GET: tblSeleccionarOfertas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSeleccionarOfertas tblSeleccionarOfertas = db.tblSeleccionarOfertas.Find(id);
            if (tblSeleccionarOfertas == null)
            {
                return HttpNotFound();
            }
            return View(tblSeleccionarOfertas);
        }

        // GET: tblSeleccionarOfertas/Create
        public ActionResult Create()
        {
            ViewBag.idOfertaProveedor = new SelectList(db.tblOfertasProveedores, "idOfertaProveedor", "idOfertaProveedor");
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio");
            return View();
        }

        // POST: tblSeleccionarOfertas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSeleccionOferta,idOfertaProveedor,idProveedor")] tblSeleccionarOfertas tblSeleccionarOfertas)
        {
            if (ModelState.IsValid)
            {
                db.tblSeleccionarOfertas.Add(tblSeleccionarOfertas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOfertaProveedor = new SelectList(db.tblOfertasProveedores, "idOfertaProveedor", "idOfertaProveedor", tblSeleccionarOfertas.idOfertaProveedor);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblSeleccionarOfertas.idProveedor);
            return View(tblSeleccionarOfertas);
        }

        // GET: tblSeleccionarOfertas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSeleccionarOfertas tblSeleccionarOfertas = db.tblSeleccionarOfertas.Find(id);
            if (tblSeleccionarOfertas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOfertaProveedor = new SelectList(db.tblOfertasProveedores, "idOfertaProveedor", "idOfertaProveedor", tblSeleccionarOfertas.idOfertaProveedor);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblSeleccionarOfertas.idProveedor);
            return View(tblSeleccionarOfertas);
        }

        // POST: tblSeleccionarOfertas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSeleccionOferta,idOfertaProveedor,idProveedor")] tblSeleccionarOfertas tblSeleccionarOfertas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSeleccionarOfertas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOfertaProveedor = new SelectList(db.tblOfertasProveedores, "idOfertaProveedor", "idOfertaProveedor", tblSeleccionarOfertas.idOfertaProveedor);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblSeleccionarOfertas.idProveedor);
            return View(tblSeleccionarOfertas);
        }

        // GET: tblSeleccionarOfertas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSeleccionarOfertas tblSeleccionarOfertas = db.tblSeleccionarOfertas.Find(id);
            if (tblSeleccionarOfertas == null)
            {
                return HttpNotFound();
            }
            return View(tblSeleccionarOfertas);
        }

        // POST: tblSeleccionarOfertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSeleccionarOfertas tblSeleccionarOfertas = db.tblSeleccionarOfertas.Find(id);
            db.tblSeleccionarOfertas.Remove(tblSeleccionarOfertas);
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
