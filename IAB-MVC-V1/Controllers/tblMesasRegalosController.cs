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
    public class tblMesasRegalosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblMesasRegalos
        public ActionResult Index()
        {
            return View(db.tblMesasRegalos.ToList());
        }

        // GET: tblMesasRegalos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMesasRegalos tblMesasRegalos = db.tblMesasRegalos.Find(id);
            if (tblMesasRegalos == null)
            {
                return HttpNotFound();
            }
            return View(tblMesasRegalos);
        }

        // GET: tblMesasRegalos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblMesasRegalos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMesaRegalo,nombre,url,telefono")] tblMesasRegalos tblMesasRegalos)
        {
            if (ModelState.IsValid)
            {
                db.tblMesasRegalos.Add(tblMesasRegalos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblMesasRegalos);
        }

        // GET: tblMesasRegalos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMesasRegalos tblMesasRegalos = db.tblMesasRegalos.Find(id);
            if (tblMesasRegalos == null)
            {
                return HttpNotFound();
            }
            return View(tblMesasRegalos);
        }

        // POST: tblMesasRegalos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMesaRegalo,nombre,url,telefono")] tblMesasRegalos tblMesasRegalos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMesasRegalos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblMesasRegalos);
        }

        // GET: tblMesasRegalos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMesasRegalos tblMesasRegalos = db.tblMesasRegalos.Find(id);
            if (tblMesasRegalos == null)
            {
                return HttpNotFound();
            }
            return View(tblMesasRegalos);
        }

        // POST: tblMesasRegalos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMesasRegalos tblMesasRegalos = db.tblMesasRegalos.Find(id);
            db.tblMesasRegalos.Remove(tblMesasRegalos);
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
