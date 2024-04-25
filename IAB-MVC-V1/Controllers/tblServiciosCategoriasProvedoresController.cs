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
    public class tblServiciosCategoriasProvedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblServiciosCategoriasProvedores
        public ActionResult Index()
        {
            var tblServiciosCategoriasProvedores = db.tblServiciosCategoriasProvedores.Include(t => t.tblCategoriasProveedores);
            return View(tblServiciosCategoriasProvedores.ToList());
        }

        // GET: tblServiciosCategoriasProvedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblServiciosCategoriasProvedores tblServiciosCategoriasProvedores = db.tblServiciosCategoriasProvedores.Find(id);
            if (tblServiciosCategoriasProvedores == null)
            {
                return HttpNotFound();
            }
            return View(tblServiciosCategoriasProvedores);
        }

        // GET: tblServiciosCategoriasProvedores/Create
        public ActionResult Create()
        {
            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria");
            return View();
        }

        // POST: tblServiciosCategoriasProvedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServicioCategoProv,idCategoriaProveedor,serviciosProveedores")] tblServiciosCategoriasProvedores tblServiciosCategoriasProvedores)
        {
            if (ModelState.IsValid)
            {
                db.tblServiciosCategoriasProvedores.Add(tblServiciosCategoriasProvedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria", tblServiciosCategoriasProvedores.idCategoriaProveedor);
            return View(tblServiciosCategoriasProvedores);
        }

        // GET: tblServiciosCategoriasProvedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblServiciosCategoriasProvedores tblServiciosCategoriasProvedores = db.tblServiciosCategoriasProvedores.Find(id);
            if (tblServiciosCategoriasProvedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria", tblServiciosCategoriasProvedores.idCategoriaProveedor);
            return View(tblServiciosCategoriasProvedores);
        }

        // POST: tblServiciosCategoriasProvedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServicioCategoProv,idCategoriaProveedor,serviciosProveedores")] tblServiciosCategoriasProvedores tblServiciosCategoriasProvedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblServiciosCategoriasProvedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria", tblServiciosCategoriasProvedores.idCategoriaProveedor);
            return View(tblServiciosCategoriasProvedores);
        }

        // GET: tblServiciosCategoriasProvedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblServiciosCategoriasProvedores tblServiciosCategoriasProvedores = db.tblServiciosCategoriasProvedores.Find(id);
            if (tblServiciosCategoriasProvedores == null)
            {
                return HttpNotFound();
            }
            return View(tblServiciosCategoriasProvedores);
        }

        // POST: tblServiciosCategoriasProvedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblServiciosCategoriasProvedores tblServiciosCategoriasProvedores = db.tblServiciosCategoriasProvedores.Find(id);
            db.tblServiciosCategoriasProvedores.Remove(tblServiciosCategoriasProvedores);
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
