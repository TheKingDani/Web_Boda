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
    public class tblMunicipiosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblMunicipios
        public ActionResult Index()
        {
            var tblMunicipios = db.tblMunicipios.Include(t => t.tblEstados);
            return View(tblMunicipios.ToList());
        }

        // GET: tblMunicipios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMunicipios tblMunicipios = db.tblMunicipios.Find(id);
            if (tblMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tblMunicipios);
        }

        // GET: tblMunicipios/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado");
            return View();
        }

        // POST: tblMunicipios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMunicipio,nombreMunicipio,idEstado")] tblMunicipios tblMunicipios)
        {
            if (ModelState.IsValid)
            {
                db.tblMunicipios.Add(tblMunicipios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblMunicipios.idEstado);
            return View(tblMunicipios);
        }

        // GET: tblMunicipios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMunicipios tblMunicipios = db.tblMunicipios.Find(id);
            if (tblMunicipios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblMunicipios.idEstado);
            return View(tblMunicipios);
        }

        // POST: tblMunicipios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMunicipio,nombreMunicipio,idEstado")] tblMunicipios tblMunicipios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMunicipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblMunicipios.idEstado);
            return View(tblMunicipios);
        }

        // GET: tblMunicipios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMunicipios tblMunicipios = db.tblMunicipios.Find(id);
            if (tblMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tblMunicipios);
        }

        // POST: tblMunicipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMunicipios tblMunicipios = db.tblMunicipios.Find(id);
            db.tblMunicipios.Remove(tblMunicipios);
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
