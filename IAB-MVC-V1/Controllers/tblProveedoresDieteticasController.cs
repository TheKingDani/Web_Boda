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
    public class tblProveedoresDieteticasController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblProveedoresDieteticas
        public ActionResult Index()
        {
            var tblProveedoresDieteticas = db.tblProveedoresDieteticas.Include(t => t.tblDieteticas).Include(t => t.tblProveedores);
            return View(tblProveedoresDieteticas.ToList());
        }

        // GET: tblProveedoresDieteticas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedoresDieteticas tblProveedoresDieteticas = db.tblProveedoresDieteticas.Find(id);
            if (tblProveedoresDieteticas == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedoresDieteticas);
        }

        // GET: tblProveedoresDieteticas/Create
        public ActionResult Create()
        {
            ViewBag.idDietetica = new SelectList(db.tblDieteticas, "idDietetica", "nomDietetica");
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio");
            return View();
        }

        // POST: tblProveedoresDieteticas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProveedorDietetica,idDietetica,idProveedor")] tblProveedoresDieteticas tblProveedoresDieteticas)
        {
            if (ModelState.IsValid)
            {
                db.tblProveedoresDieteticas.Add(tblProveedoresDieteticas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDietetica = new SelectList(db.tblDieteticas, "idDietetica", "nomDietetica", tblProveedoresDieteticas.idDietetica);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblProveedoresDieteticas.idProveedor);
            return View(tblProveedoresDieteticas);
        }

        // GET: tblProveedoresDieteticas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedoresDieteticas tblProveedoresDieteticas = db.tblProveedoresDieteticas.Find(id);
            if (tblProveedoresDieteticas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDietetica = new SelectList(db.tblDieteticas, "idDietetica", "nomDietetica", tblProveedoresDieteticas.idDietetica);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblProveedoresDieteticas.idProveedor);
            return View(tblProveedoresDieteticas);
        }

        // POST: tblProveedoresDieteticas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProveedorDietetica,idDietetica,idProveedor")] tblProveedoresDieteticas tblProveedoresDieteticas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProveedoresDieteticas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDietetica = new SelectList(db.tblDieteticas, "idDietetica", "nomDietetica", tblProveedoresDieteticas.idDietetica);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblProveedoresDieteticas.idProveedor);
            return View(tblProveedoresDieteticas);
        }

        // GET: tblProveedoresDieteticas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedoresDieteticas tblProveedoresDieteticas = db.tblProveedoresDieteticas.Find(id);
            if (tblProveedoresDieteticas == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedoresDieteticas);
        }

        // POST: tblProveedoresDieteticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProveedoresDieteticas tblProveedoresDieteticas = db.tblProveedoresDieteticas.Find(id);
            db.tblProveedoresDieteticas.Remove(tblProveedoresDieteticas);
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
