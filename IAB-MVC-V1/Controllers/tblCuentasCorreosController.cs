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
    public class tblCuentasCorreosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblCuentasCorreos
        public ActionResult Index()
        {
            var tblCuentasCorreo = db.tblCuentasCorreo.Include(t => t.tblNovios);
            return View(tblCuentasCorreo.ToList());
        }

        // GET: tblCuentasCorreos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCuentasCorreo tblCuentasCorreo = db.tblCuentasCorreo.Find(id);
            if (tblCuentasCorreo == null)
            {
                return HttpNotFound();
            }
            return View(tblCuentasCorreo);
        }

        // GET: tblCuentasCorreos/Create
        public ActionResult Create()
        {
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblCuentasCorreos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCuentaCorreo,idNovios,smtpServidor,usuario,password,port")] tblCuentasCorreo tblCuentasCorreo)
        {
            if (ModelState.IsValid)
            {
                db.tblCuentasCorreo.Add(tblCuentasCorreo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblCuentasCorreo.idNovios);
            return View(tblCuentasCorreo);
        }

        // GET: tblCuentasCorreos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCuentasCorreo tblCuentasCorreo = db.tblCuentasCorreo.Find(id);
            if (tblCuentasCorreo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblCuentasCorreo.idNovios);
            return View(tblCuentasCorreo);
        }

        // POST: tblCuentasCorreos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCuentaCorreo,idNovios,smtpServidor,usuario,password,port")] tblCuentasCorreo tblCuentasCorreo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCuentasCorreo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblCuentasCorreo.idNovios);
            return View(tblCuentasCorreo);
        }

        // GET: tblCuentasCorreos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCuentasCorreo tblCuentasCorreo = db.tblCuentasCorreo.Find(id);
            if (tblCuentasCorreo == null)
            {
                return HttpNotFound();
            }
            return View(tblCuentasCorreo);
        }

        // POST: tblCuentasCorreos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCuentasCorreo tblCuentasCorreo = db.tblCuentasCorreo.Find(id);
            db.tblCuentasCorreo.Remove(tblCuentasCorreo);
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
