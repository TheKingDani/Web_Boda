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
    public class tblPlantillasController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblPlantillas
        public ActionResult Index()
        {
            return View(db.tblPlantillas.ToList());
        }

        // GET: tblPlantillas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantillas tblPlantillas = db.tblPlantillas.Find(id);
            if (tblPlantillas == null)
            {
                return HttpNotFound();
            }
            return View(tblPlantillas);
        }

        // GET: tblPlantillas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblPlantillas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPlantilla,nombre")] tblPlantillas tblPlantillas)
        {
            if (ModelState.IsValid)
            {
                db.tblPlantillas.Add(tblPlantillas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPlantillas);
        }

        // GET: tblPlantillas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantillas tblPlantillas = db.tblPlantillas.Find(id);
            if (tblPlantillas == null)
            {
                return HttpNotFound();
            }
            return View(tblPlantillas);
        }

        // POST: tblPlantillas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPlantilla,nombre")] tblPlantillas tblPlantillas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPlantillas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPlantillas);
        }

        // GET: tblPlantillas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPlantillas tblPlantillas = db.tblPlantillas.Find(id);
            if (tblPlantillas == null)
            {
                return HttpNotFound();
            }
            return View(tblPlantillas);
        }

        // POST: tblPlantillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPlantillas tblPlantillas = db.tblPlantillas.Find(id);
            db.tblPlantillas.Remove(tblPlantillas);
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
