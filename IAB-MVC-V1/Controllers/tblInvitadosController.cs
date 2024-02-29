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
    public class tblInvitadosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblInvitados
        public ActionResult Index()
        {
            var tblInvitados = db.tblInvitados.Include(t => t.tblTipoInvitado).Include(t => t.tblNovios);
            return View(tblInvitados.ToList());
        }

        // GET: tblInvitados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvitados tblInvitados = db.tblInvitados.Find(id);
            if (tblInvitados == null)
            {
                return HttpNotFound();
            }
            return View(tblInvitados);
        }

        // GET: tblInvitados/Create
        public ActionResult Create()
        {
            ViewBag.idTipoInvitado = new SelectList(db.tblTipoInvitado, "idTipoInvitado", "tipoInvitado");
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia");
            return View();
        }

        // POST: tblInvitados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idInvitado,apodo,nombre,aPaterno,aMaterno,boletos,idGenero,boletosConfirmados,correo,idTipoInvitado,vienePor,telefono,idTipoMenu,accedio,llegoWeb,contrasena,invitacionEnviada,soloMisa,asistira,qrEnviado,qrConfirmado,asistioBoda,mesa,idNovios,mensaje,regalo,mensajeRegalo,idIdioma")] tblInvitados tblInvitados)
        {
            if (ModelState.IsValid)
            {
                db.tblInvitados.Add(tblInvitados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoInvitado = new SelectList(db.tblTipoInvitado, "idTipoInvitado", "tipoInvitado", tblInvitados.idTipoInvitado);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblInvitados.idNovios);
            return View(tblInvitados);
        }

        // GET: tblInvitados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvitados tblInvitados = db.tblInvitados.Find(id);
            if (tblInvitados == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoInvitado = new SelectList(db.tblTipoInvitado, "idTipoInvitado", "tipoInvitado", tblInvitados.idTipoInvitado);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblInvitados.idNovios);
            return View(tblInvitados);
        }

        // POST: tblInvitados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idInvitado,apodo,nombre,aPaterno,aMaterno,boletos,idGenero,boletosConfirmados,correo,idTipoInvitado,vienePor,telefono,idTipoMenu,accedio,llegoWeb,contrasena,invitacionEnviada,soloMisa,asistira,qrEnviado,qrConfirmado,asistioBoda,mesa,idNovios,mensaje,regalo,mensajeRegalo,idIdioma")] tblInvitados tblInvitados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblInvitados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoInvitado = new SelectList(db.tblTipoInvitado, "idTipoInvitado", "tipoInvitado", tblInvitados.idTipoInvitado);
            ViewBag.idNovios = new SelectList(db.tblNovios, "idNovios", "nombreNovia", tblInvitados.idNovios);
            return View(tblInvitados);
        }

        // GET: tblInvitados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvitados tblInvitados = db.tblInvitados.Find(id);
            if (tblInvitados == null)
            {
                return HttpNotFound();
            }
            return View(tblInvitados);
        }

        // POST: tblInvitados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInvitados tblInvitados = db.tblInvitados.Find(id);
            db.tblInvitados.Remove(tblInvitados);
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
