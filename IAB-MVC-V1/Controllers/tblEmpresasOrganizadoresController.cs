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
    public class tblEmpresasOrganizadoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblEmpresasOrganizadores
        public ActionResult Index()
        {
            var tblEmpresasOrganizadores = db.tblEmpresasOrganizadores.Include(t => t.tblEstados).Include(t => t.tblMunicipios);
            return View(tblEmpresasOrganizadores.ToList());
        }

        // GET: tblEmpresasOrganizadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresasOrganizadores tblEmpresasOrganizadores = db.tblEmpresasOrganizadores.Find(id);
            if (tblEmpresasOrganizadores == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresasOrganizadores);
        }

        // GET: tblEmpresasOrganizadores/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado");
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio");
            return View();
        }

        // POST: tblEmpresasOrganizadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpresaOrganizador,nombreEmpresa,direccion,idEstado,idMunicipio,telefono,paginaWeb")] tblEmpresasOrganizadores tblEmpresasOrganizadores)
        {
            if (ModelState.IsValid)
            {
                db.tblEmpresasOrganizadores.Add(tblEmpresasOrganizadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblEmpresasOrganizadores.idEstado);
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio", tblEmpresasOrganizadores.idMunicipio);
            return View(tblEmpresasOrganizadores);
        }

        // GET: tblEmpresasOrganizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresasOrganizadores tblEmpresasOrganizadores = db.tblEmpresasOrganizadores.Find(id);
            if (tblEmpresasOrganizadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblEmpresasOrganizadores.idEstado);
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio", tblEmpresasOrganizadores.idMunicipio);
            return View(tblEmpresasOrganizadores);
        }

        // POST: tblEmpresasOrganizadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpresaOrganizador,nombreEmpresa,direccion,idEstado,idMunicipio,telefono,paginaWeb")] tblEmpresasOrganizadores tblEmpresasOrganizadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpresasOrganizadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblEmpresasOrganizadores.idEstado);
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio", tblEmpresasOrganizadores.idMunicipio);
            return View(tblEmpresasOrganizadores);
        }

        // GET: tblEmpresasOrganizadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresasOrganizadores tblEmpresasOrganizadores = db.tblEmpresasOrganizadores.Find(id);
            if (tblEmpresasOrganizadores == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresasOrganizadores);
        }

        // POST: tblEmpresasOrganizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmpresasOrganizadores tblEmpresasOrganizadores = db.tblEmpresasOrganizadores.Find(id);
            db.tblEmpresasOrganizadores.Remove(tblEmpresasOrganizadores);
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
