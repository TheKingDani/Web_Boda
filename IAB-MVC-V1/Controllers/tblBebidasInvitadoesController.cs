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
    public class tblBebidasInvitadoesController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblBebidasInvitadoes
        public ActionResult Index()
        {
            var tblBebidasInvitado = db.tblBebidasInvitado.Include(t => t.tblBebidasNovios).Include(t => t.tblInvitados);
            return View(tblBebidasInvitado.ToList());
        }

        // GET: tblBebidasInvitadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBebidasInvitado tblBebidasInvitado = db.tblBebidasInvitado.Find(id);
            if (tblBebidasInvitado == null)
            {
                return HttpNotFound();
            }
            return View(tblBebidasInvitado);
        }

        // GET: tblBebidasInvitadoes/Create
        public ActionResult Create()
        {
            ViewBag.idBebidaNovios = new SelectList(db.tblBebidasNovios, "idBebidaNovios", "idBebidaNovios");
            ViewBag.idInvitado = new SelectList(db.tblInvitados, "idInvitado", "apodo");
            return View();
        }

        // POST: tblBebidasInvitadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBebidaInvitado,idBebidaNovios,idInvitado")] tblBebidasInvitado tblBebidasInvitado)
        {
            if (ModelState.IsValid)
            {
                db.tblBebidasInvitado.Add(tblBebidasInvitado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBebidaNovios = new SelectList(db.tblBebidasNovios, "idBebidaNovios", "idBebidaNovios", tblBebidasInvitado.idBebidaNovios);
            ViewBag.idInvitado = new SelectList(db.tblInvitados, "idInvitado", "apodo", tblBebidasInvitado.idInvitado);
            return View(tblBebidasInvitado);
        }

        // GET: tblBebidasInvitadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBebidasInvitado tblBebidasInvitado = db.tblBebidasInvitado.Find(id);
            if (tblBebidasInvitado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBebidaNovios = new SelectList(db.tblBebidasNovios, "idBebidaNovios", "idBebidaNovios", tblBebidasInvitado.idBebidaNovios);
            ViewBag.idInvitado = new SelectList(db.tblInvitados, "idInvitado", "apodo", tblBebidasInvitado.idInvitado);
            return View(tblBebidasInvitado);
        }

        // POST: tblBebidasInvitadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBebidaInvitado,idBebidaNovios,idInvitado")] tblBebidasInvitado tblBebidasInvitado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBebidasInvitado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBebidaNovios = new SelectList(db.tblBebidasNovios, "idBebidaNovios", "idBebidaNovios", tblBebidasInvitado.idBebidaNovios);
            ViewBag.idInvitado = new SelectList(db.tblInvitados, "idInvitado", "apodo", tblBebidasInvitado.idInvitado);
            return View(tblBebidasInvitado);
        }

        // GET: tblBebidasInvitadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBebidasInvitado tblBebidasInvitado = db.tblBebidasInvitado.Find(id);
            if (tblBebidasInvitado == null)
            {
                return HttpNotFound();
            }
            return View(tblBebidasInvitado);
        }

        // POST: tblBebidasInvitadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBebidasInvitado tblBebidasInvitado = db.tblBebidasInvitado.Find(id);
            db.tblBebidasInvitado.Remove(tblBebidasInvitado);
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
