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
    public class tblOrganizadoresBodasController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblOrganizadoresBodas
        public ActionResult Index()
        {
            var tblOrganizadoresBodas = db.tblOrganizadoresBodas.Include(t => t.tblEmpresasOrganizadores);
            return View(tblOrganizadoresBodas.ToList());
        }

        // GET: tblOrganizadoresBodas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrganizadoresBodas tblOrganizadoresBodas = db.tblOrganizadoresBodas.Find(id);
            if (tblOrganizadoresBodas == null)
            {
                return HttpNotFound();
            }
            return View(tblOrganizadoresBodas);
        }

        // GET: tblOrganizadoresBodas/Create
        public ActionResult Create()
        {
            ViewBag.idEmpresaOrganizador = new SelectList(db.tblEmpresasOrganizadores, "idEmpresaOrganizador", "nombreEmpresa");
            return View();
        }

        // POST: tblOrganizadoresBodas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOrganizadorBoda,idEmpresaOrganizador,nombreOrganizador,email,tel,activo")] tblOrganizadoresBodas tblOrganizadoresBodas)
        {
            if (ModelState.IsValid)
            {
                db.tblOrganizadoresBodas.Add(tblOrganizadoresBodas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpresaOrganizador = new SelectList(db.tblEmpresasOrganizadores, "idEmpresaOrganizador", "nombreEmpresa", tblOrganizadoresBodas.idEmpresaOrganizador);
            return View(tblOrganizadoresBodas);
        }

        // GET: tblOrganizadoresBodas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrganizadoresBodas tblOrganizadoresBodas = db.tblOrganizadoresBodas.Find(id);
            if (tblOrganizadoresBodas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpresaOrganizador = new SelectList(db.tblEmpresasOrganizadores, "idEmpresaOrganizador", "nombreEmpresa", tblOrganizadoresBodas.idEmpresaOrganizador);
            return View(tblOrganizadoresBodas);
        }

        // POST: tblOrganizadoresBodas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOrganizadorBoda,idEmpresaOrganizador,nombreOrganizador,email,tel,activo")] tblOrganizadoresBodas tblOrganizadoresBodas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOrganizadoresBodas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpresaOrganizador = new SelectList(db.tblEmpresasOrganizadores, "idEmpresaOrganizador", "nombreEmpresa", tblOrganizadoresBodas.idEmpresaOrganizador);
            return View(tblOrganizadoresBodas);
        }

        // GET: tblOrganizadoresBodas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrganizadoresBodas tblOrganizadoresBodas = db.tblOrganizadoresBodas.Find(id);
            if (tblOrganizadoresBodas == null)
            {
                return HttpNotFound();
            }
            return View(tblOrganizadoresBodas);
        }

        // POST: tblOrganizadoresBodas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOrganizadoresBodas tblOrganizadoresBodas = db.tblOrganizadoresBodas.Find(id);
            db.tblOrganizadoresBodas.Remove(tblOrganizadoresBodas);
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
