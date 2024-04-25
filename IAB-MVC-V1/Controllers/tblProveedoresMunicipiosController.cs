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
    public class tblProveedoresMunicipiosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblProveedoresMunicipios
        public ActionResult Index()
        {
            var tblProveedoresMunicipios = db.tblProveedoresMunicipios.Include(t => t.tblMunicipios).Include(t => t.tblProveedores);
            return View(tblProveedoresMunicipios.ToList());
        }

        // GET: tblProveedoresMunicipios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedoresMunicipios tblProveedoresMunicipios = db.tblProveedoresMunicipios.Find(id);
            if (tblProveedoresMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedoresMunicipios);
        }

        // GET: tblProveedoresMunicipios/Create
        public ActionResult Create()
        {
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio");
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio");
            return View();
        }

        // POST: tblProveedoresMunicipios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProveedorMunicipio,idProveedor,idMunicipio")] tblProveedoresMunicipios tblProveedoresMunicipios)
        {
            if (ModelState.IsValid)
            {
                db.tblProveedoresMunicipios.Add(tblProveedoresMunicipios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio", tblProveedoresMunicipios.idMunicipio);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblProveedoresMunicipios.idProveedor);
            return View(tblProveedoresMunicipios);
        }

        // GET: tblProveedoresMunicipios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedoresMunicipios tblProveedoresMunicipios = db.tblProveedoresMunicipios.Find(id);
            if (tblProveedoresMunicipios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio", tblProveedoresMunicipios.idMunicipio);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblProveedoresMunicipios.idProveedor);
            return View(tblProveedoresMunicipios);
        }

        // POST: tblProveedoresMunicipios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProveedorMunicipio,idProveedor,idMunicipio")] tblProveedoresMunicipios tblProveedoresMunicipios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProveedoresMunicipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio", tblProveedoresMunicipios.idMunicipio);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblProveedoresMunicipios.idProveedor);
            return View(tblProveedoresMunicipios);
        }

        // GET: tblProveedoresMunicipios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedoresMunicipios tblProveedoresMunicipios = db.tblProveedoresMunicipios.Find(id);
            if (tblProveedoresMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedoresMunicipios);
        }

        // POST: tblProveedoresMunicipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProveedoresMunicipios tblProveedoresMunicipios = db.tblProveedoresMunicipios.Find(id);
            db.tblProveedoresMunicipios.Remove(tblProveedoresMunicipios);
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
