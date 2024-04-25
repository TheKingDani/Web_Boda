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
    public class tblSeleccionarOrganizadoresBodasController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblSeleccionarOrganizadoresBodas
        public ActionResult Index()
        {
            var tblSeleccionarOrganizadoresBodas = db.tblSeleccionarOrganizadoresBodas.Include(t => t.tblOrganizadoresBodas).Include(t => t.tblNovios);
            return View(tblSeleccionarOrganizadoresBodas.ToList());
        }

        // GET: tblSeleccionarOrganizadoresBodas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSeleccionarOrganizadoresBodas tblSeleccionarOrganizadoresBodas = db.tblSeleccionarOrganizadoresBodas.Find(id);
            if (tblSeleccionarOrganizadoresBodas == null)
            {
                return HttpNotFound();
            }
            return View(tblSeleccionarOrganizadoresBodas);
        }

        // GET: tblSeleccionarOrganizadoresBodas/Create
        public ActionResult Create()
        {
            ViewBag.idOrganizadorBoda = new SelectList(db.tblOrganizadoresBodas, "idOrganizadorBoda", "nombreOrganizador");
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblSeleccionarOrganizadoresBodas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSeleccionarOrganizadorBoda,idNovios,idOrganizadorBoda")] tblSeleccionarOrganizadoresBodas tblSeleccionarOrganizadoresBodas)
        {
            if (ModelState.IsValid)
            {
                db.tblSeleccionarOrganizadoresBodas.Add(tblSeleccionarOrganizadoresBodas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOrganizadorBoda = new SelectList(db.tblOrganizadoresBodas, "idOrganizadorBoda", "nombreOrganizador", tblSeleccionarOrganizadoresBodas.idOrganizadorBoda);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblSeleccionarOrganizadoresBodas.idNovios);
            return View(tblSeleccionarOrganizadoresBodas);
        }

        // GET: tblSeleccionarOrganizadoresBodas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSeleccionarOrganizadoresBodas tblSeleccionarOrganizadoresBodas = db.tblSeleccionarOrganizadoresBodas.Find(id);
            if (tblSeleccionarOrganizadoresBodas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOrganizadorBoda = new SelectList(db.tblOrganizadoresBodas, "idOrganizadorBoda", "nombreOrganizador", tblSeleccionarOrganizadoresBodas.idOrganizadorBoda);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblSeleccionarOrganizadoresBodas.idNovios);
            return View(tblSeleccionarOrganizadoresBodas);
        }

        // POST: tblSeleccionarOrganizadoresBodas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSeleccionarOrganizadorBoda,idNovios,idOrganizadorBoda")] tblSeleccionarOrganizadoresBodas tblSeleccionarOrganizadoresBodas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSeleccionarOrganizadoresBodas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOrganizadorBoda = new SelectList(db.tblOrganizadoresBodas, "idOrganizadorBoda", "nombreOrganizador", tblSeleccionarOrganizadoresBodas.idOrganizadorBoda);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblSeleccionarOrganizadoresBodas.idNovios);
            return View(tblSeleccionarOrganizadoresBodas);
        }

        // GET: tblSeleccionarOrganizadoresBodas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSeleccionarOrganizadoresBodas tblSeleccionarOrganizadoresBodas = db.tblSeleccionarOrganizadoresBodas.Find(id);
            if (tblSeleccionarOrganizadoresBodas == null)
            {
                return HttpNotFound();
            }
            return View(tblSeleccionarOrganizadoresBodas);
        }

        // POST: tblSeleccionarOrganizadoresBodas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSeleccionarOrganizadoresBodas tblSeleccionarOrganizadoresBodas = db.tblSeleccionarOrganizadoresBodas.Find(id);
            db.tblSeleccionarOrganizadoresBodas.Remove(tblSeleccionarOrganizadoresBodas);
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
