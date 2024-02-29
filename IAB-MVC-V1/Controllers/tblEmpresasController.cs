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
    public class tblEmpresasController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblEmpresas
        public ActionResult Index()
        {
            return View(db.tblEmpresas.OrderBy(x => x.nombreEmpresa).ToList());
        }

        // GET: tblEmpresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresas tblEmpresas = db.tblEmpresas.Find(id);
            if (tblEmpresas == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresas);
        }

        // GET: tblEmpresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblEmpresas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpresa,nombreEmpresa")] tblEmpresas tblEmpresas)
        {
            if (ModelState.IsValid)
            {
                db.tblEmpresas.Add(tblEmpresas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEmpresas);
        }

        // GET: tblEmpresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresas tblEmpresas = db.tblEmpresas.Find(id);
            if (tblEmpresas == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresas);
        }

        // POST: tblEmpresas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpresa,nombreEmpresa")] tblEmpresas tblEmpresas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpresas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmpresas);
        }

        // GET: tblEmpresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresas tblEmpresas = db.tblEmpresas.Find(id);
            if (tblEmpresas == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresas);
        }

        // POST: tblEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmpresas tblEmpresas = db.tblEmpresas.Find(id);
            db.tblEmpresas.Remove(tblEmpresas);
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
