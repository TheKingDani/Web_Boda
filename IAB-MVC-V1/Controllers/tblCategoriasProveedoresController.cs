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
    public class tblCategoriasProveedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblCategoriasProveedores
        public ActionResult Index()
        {
            return View(db.tblCategoriasProveedores.ToList());
        }


        public ActionResult ModalServicios()
        {
            return PartialView("_ModalServicios");
        }



        // GET: tblCategoriasProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategoriasProveedores tblCategoriasProveedores = db.tblCategoriasProveedores.Find(id);
            if (tblCategoriasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblCategoriasProveedores);
        }

        // GET: tblCategoriasProveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblCategoriasProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCategoriaProveedor,nombreCategoria,descripcion")] tblCategoriasProveedores tblCategoriasProveedores)
        {
            if (ModelState.IsValid)
            {
                db.tblCategoriasProveedores.Add(tblCategoriasProveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCategoriasProveedores);
        }

        // GET: tblCategoriasProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategoriasProveedores tblCategoriasProveedores = db.tblCategoriasProveedores.Find(id);
            if (tblCategoriasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblCategoriasProveedores);
        }

        // POST: tblCategoriasProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCategoriaProveedor,nombreCategoria,descripcion")] tblCategoriasProveedores tblCategoriasProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCategoriasProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCategoriasProveedores);
        }

        // GET: tblCategoriasProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategoriasProveedores tblCategoriasProveedores = db.tblCategoriasProveedores.Find(id);
            if (tblCategoriasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblCategoriasProveedores);
        }

        // POST: tblCategoriasProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCategoriasProveedores tblCategoriasProveedores = db.tblCategoriasProveedores.Find(id);
            db.tblCategoriasProveedores.Remove(tblCategoriasProveedores);
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
