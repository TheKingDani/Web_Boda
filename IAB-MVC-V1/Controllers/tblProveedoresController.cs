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
    public class tblProveedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblProveedores
        public ActionResult Index()
        {
            var tblProveedores = db.tblProveedores.Include(t => t.tblCategoriasProveedores).Include(t => t.tblEstados);
            return View(tblProveedores.ToList());
        }

        // GET: tblProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedores tblProveedores = db.tblProveedores.Find(id);
            if (tblProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedores);
        }

        // GET: tblProveedores/Create
        public ActionResult Create()
        {
            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria");
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado");
            return View();
        }

        // POST: tblProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProveedor,nomNegocio,idCategoriaProveedor,sitioWeb,tel,email,codigoPostal,direccion,ciudad,pais,idEstado,precioInicial")] tblProveedores tblProveedores)
        {
            if (ModelState.IsValid)
            {
                db.tblProveedores.Add(tblProveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria", tblProveedores.idCategoriaProveedor);
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblProveedores.idEstado);
            return View(tblProveedores);
        }

        // GET: tblProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedores tblProveedores = db.tblProveedores.Find(id);
            if (tblProveedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria", tblProveedores.idCategoriaProveedor);
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblProveedores.idEstado);
            return View(tblProveedores);
        }

        // POST: tblProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProveedor,nomNegocio,idCategoriaProveedor,sitioWeb,tel,email,codigoPostal,direccion,ciudad,pais,idEstado,precioInicial")] tblProveedores tblProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria", tblProveedores.idCategoriaProveedor);
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblProveedores.idEstado);
            return View(tblProveedores);
        }

        // GET: tblProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedores tblProveedores = db.tblProveedores.Find(id);
            if (tblProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedores);
        }

        // POST: tblProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProveedores tblProveedores = db.tblProveedores.Find(id);
            db.tblProveedores.Remove(tblProveedores);
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
