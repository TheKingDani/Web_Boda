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
    public class tblRedesProveedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblRedesProveedores
        public ActionResult Index()
        {
            var tblRedesProveedores = db.tblRedesProveedores.Include(t => t.tblProveedores).Include(t => t.tblRedesSociales);
            return View(tblRedesProveedores.ToList());
        }

        // GET: tblRedesProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRedesProveedores tblRedesProveedores = db.tblRedesProveedores.Find(id);
            if (tblRedesProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblRedesProveedores);
        }

        // GET: tblRedesProveedores/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio");
            ViewBag.idRedSocial = new SelectList(db.tblRedesSociales, "idRedSocial", "redSocial");
            return View();
        }

        // POST: tblRedesProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRedProveedor,idRedSocial,idProveedor,link")] tblRedesProveedores tblRedesProveedores)
        {
            if (ModelState.IsValid)
            {
                db.tblRedesProveedores.Add(tblRedesProveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblRedesProveedores.idProveedor);
            ViewBag.idRedSocial = new SelectList(db.tblRedesSociales, "idRedSocial", "redSocial", tblRedesProveedores.idRedSocial);
            return View(tblRedesProveedores);
        }

        // GET: tblRedesProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRedesProveedores tblRedesProveedores = db.tblRedesProveedores.Find(id);
            if (tblRedesProveedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblRedesProveedores.idProveedor);
            ViewBag.idRedSocial = new SelectList(db.tblRedesSociales, "idRedSocial", "redSocial", tblRedesProveedores.idRedSocial);
            return View(tblRedesProveedores);
        }

        // POST: tblRedesProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRedProveedor,idRedSocial,idProveedor,link")] tblRedesProveedores tblRedesProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRedesProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblRedesProveedores.idProveedor);
            ViewBag.idRedSocial = new SelectList(db.tblRedesSociales, "idRedSocial", "redSocial", tblRedesProveedores.idRedSocial);
            return View(tblRedesProveedores);
        }

        // GET: tblRedesProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRedesProveedores tblRedesProveedores = db.tblRedesProveedores.Find(id);
            if (tblRedesProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblRedesProveedores);
        }

        // POST: tblRedesProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRedesProveedores tblRedesProveedores = db.tblRedesProveedores.Find(id);
            db.tblRedesProveedores.Remove(tblRedesProveedores);
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
