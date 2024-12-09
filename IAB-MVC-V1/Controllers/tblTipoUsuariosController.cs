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
    public class tblTipoUsuariosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblTipoUsuarios
        public ActionResult Index()
        {
            return View(db.tblTipoUsuarios.ToList());
        }

        // GET: tblTipoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipoUsuarios tblTipoUsuarios = db.tblTipoUsuarios.Find(id);
            if (tblTipoUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblTipoUsuarios);
        }

        // GET: tblTipoUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblTipoUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipoUsuarioID,nombreTipoUsuario")] tblTipoUsuarios tblTipoUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.tblTipoUsuarios.Add(tblTipoUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblTipoUsuarios);
        }

        // GET: tblTipoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipoUsuarios tblTipoUsuarios = db.tblTipoUsuarios.Find(id);
            if (tblTipoUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblTipoUsuarios);
        }

        // POST: tblTipoUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipoUsuarioID,nombreTipoUsuario")] tblTipoUsuarios tblTipoUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTipoUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblTipoUsuarios);
        }

        // GET: tblTipoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipoUsuarios tblTipoUsuarios = db.tblTipoUsuarios.Find(id);
            if (tblTipoUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblTipoUsuarios);
        }

        // POST: tblTipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTipoUsuarios tblTipoUsuarios = db.tblTipoUsuarios.Find(id);
            db.tblTipoUsuarios.Remove(tblTipoUsuarios);
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
