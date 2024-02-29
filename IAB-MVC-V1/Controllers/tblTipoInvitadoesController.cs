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
    public class tblTipoInvitadoesController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblTipoInvitadoes
        public ActionResult Index()
        {
            var tblTipoInvitado = db.tblTipoInvitado.Include(t => t.tblNovios);
            return View(tblTipoInvitado.ToList());
        }

        // GET: tblTipoInvitadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipoInvitado tblTipoInvitado = db.tblTipoInvitado.Find(id);
            if (tblTipoInvitado == null)
            {
                return HttpNotFound();
            }
            return View(tblTipoInvitado);
        }

        // GET: tblTipoInvitadoes/Create
        public ActionResult Create()
        {
            ViewBag.idNoviosTI = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblTipoInvitadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoInvitado,tipoInvitado,tituloCorreo,descripcion,archivoBienvenida,idNoviosTI")] tblTipoInvitado tblTipoInvitado)
        {
            if (ModelState.IsValid)
            {
                db.tblTipoInvitado.Add(tblTipoInvitado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNoviosTI = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblTipoInvitado.idNoviosTI);
            return View(tblTipoInvitado);
        }

        // GET: tblTipoInvitadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipoInvitado tblTipoInvitado = db.tblTipoInvitado.Find(id);
            if (tblTipoInvitado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNoviosTI = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblTipoInvitado.idNoviosTI);
            return View(tblTipoInvitado);
        }

        // POST: tblTipoInvitadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoInvitado,tipoInvitado,tituloCorreo,descripcion,archivoBienvenida,idNoviosTI")] tblTipoInvitado tblTipoInvitado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTipoInvitado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNoviosTI = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblTipoInvitado.idNoviosTI);
            return View(tblTipoInvitado);
        }

        // GET: tblTipoInvitadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTipoInvitado tblTipoInvitado = db.tblTipoInvitado.Find(id);
            if (tblTipoInvitado == null)
            {
                return HttpNotFound();
            }
            return View(tblTipoInvitado);
        }

        // POST: tblTipoInvitadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTipoInvitado tblTipoInvitado = db.tblTipoInvitado.Find(id);
            db.tblTipoInvitado.Remove(tblTipoInvitado);
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
