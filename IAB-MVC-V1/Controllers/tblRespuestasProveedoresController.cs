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
    public class tblRespuestasProveedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblRespuestasProveedores
        public ActionResult Index()
        {
            var tblRespuestasProveedores = db.tblRespuestasProveedores.Include(t => t.tblPreguntasProveedores).Include(t => t.tblProveedores);
            return View(tblRespuestasProveedores.ToList());
        }

        // GET: tblRespuestasProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRespuestasProveedores tblRespuestasProveedores = db.tblRespuestasProveedores.Find(id);
            if (tblRespuestasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblRespuestasProveedores);
        }

        // GET: tblRespuestasProveedores/Create
        public ActionResult Create()
        {
            ViewBag.idPreguntaProveedor = new SelectList(db.tblPreguntasProveedores, "idPreguntaProveedor", "Pregunta");
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio");
            return View();
        }

        // POST: tblRespuestasProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRespuestaProveedor,idPreguntaProveedor,idProveedor,Respuesta")] tblRespuestasProveedores tblRespuestasProveedores)
        {
            if (ModelState.IsValid)
            {
                db.tblRespuestasProveedores.Add(tblRespuestasProveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPreguntaProveedor = new SelectList(db.tblPreguntasProveedores, "idPreguntaProveedor", "Pregunta", tblRespuestasProveedores.idPreguntaProveedor);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblRespuestasProveedores.idProveedor);
            return View(tblRespuestasProveedores);
        }

        // GET: tblRespuestasProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRespuestasProveedores tblRespuestasProveedores = db.tblRespuestasProveedores.Find(id);
            if (tblRespuestasProveedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPreguntaProveedor = new SelectList(db.tblPreguntasProveedores, "idPreguntaProveedor", "Pregunta", tblRespuestasProveedores.idPreguntaProveedor);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblRespuestasProveedores.idProveedor);
            return View(tblRespuestasProveedores);
        }

        // POST: tblRespuestasProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRespuestaProveedor,idPreguntaProveedor,idProveedor,Respuesta")] tblRespuestasProveedores tblRespuestasProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRespuestasProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPreguntaProveedor = new SelectList(db.tblPreguntasProveedores, "idPreguntaProveedor", "Pregunta", tblRespuestasProveedores.idPreguntaProveedor);
            ViewBag.idProveedor = new SelectList(db.tblProveedores, "idProveedor", "nomNegocio", tblRespuestasProveedores.idProveedor);
            return View(tblRespuestasProveedores);
        }

        // GET: tblRespuestasProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRespuestasProveedores tblRespuestasProveedores = db.tblRespuestasProveedores.Find(id);
            if (tblRespuestasProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblRespuestasProveedores);
        }

        // POST: tblRespuestasProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRespuestasProveedores tblRespuestasProveedores = db.tblRespuestasProveedores.Find(id);
            db.tblRespuestasProveedores.Remove(tblRespuestasProveedores);
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
