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
    public class tblNoviosController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        // GET: tblNovios
        public ActionResult Index()
        {
            return View(db.tblNovios.OrderBy(x => x.nombreNovia).ToList());
        }

        // GET: tblNovios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNovios tblNovios = db.tblNovios.Find(id);
            if (tblNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblNovios);
        }

        // GET: tblNovios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblNovios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idNovios,nombreNovia,aPNovia,aMNovia,nombreNovio,aPNovio,aMNovio,fechaRegistro,dominio,padrinoNombre,padrinoApellido,madrinaNombre,madrinaApellido,misaLugar,misaHora,misaFecha,recepcionLugar,recepcionHora,recepcionFecha,fiestaLugar,fiestaHora,fiestaFecha,password,correoRegistro,telRegistro,idPlantilla,activo,papaNovioNombre,mamaNovioNombre,papaNoviaNombre,mamaNoviaNombre,facebookNovio,facebookNovia,twitterNovio,twitterNovia,instagramNovio,instagramNovia,validacionCorreo,misaLatitud,misaLongitud,recepcionLatitud,recepcionLongitud,fiestaLatitud,fiestaLongitud,dominioExterno")] tblNovios tblNovios)
        {
            if (ModelState.IsValid)
            {
             
                db.tblNovios.Add(tblNovios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblNovios);
        }

        // GET: tblNovios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNovios tblNovios = db.tblNovios.Find(id);
            if (tblNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblNovios);
        }

        // POST: tblNovios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idNovios,nombreNovia,aPNovia,aMNovia,nombreNovio,aPNovio,aMNovio,fechaRegistro,dominio,padrinoNombre,padrinoApellido,madrinaNombre,madrinaApellido,misaLugar,misaHora,misaFecha,recepcionLugar,recepcionHora,recepcionFecha,fiestaLugar,fiestaHora,fiestaFecha,password,correoRegistro,telRegistro,idPlantilla,activo,papaNovioNombre,mamaNovioNombre,papaNoviaNombre,mamaNoviaNombre,facebookNovio,facebookNovia,twitterNovio,twitterNovia,instagramNovio,instagramNovia,validacionCorreo,misaLatitud,misaLongitud,recepcionLatitud,recepcionLongitud,fiestaLatitud,fiestaLongitud,dominioExterno")] tblNovios tblNovios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblNovios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblNovios);
        }

        // GET: tblNovios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNovios tblNovios = db.tblNovios.Find(id);
            if (tblNovios == null)
            {
                return HttpNotFound();
            }
            return View(tblNovios);
        }

        // POST: tblNovios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblNovios tblNovios = db.tblNovios.Find(id);
            db.tblNovios.Remove(tblNovios);
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
