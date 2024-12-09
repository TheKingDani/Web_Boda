using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IAB_MVC_V1.Models;
using IAB_MVC_V1.ViewModels;
using System.Data.SqlClient;
using System.Data;

namespace IAB_MVC_V1.Controllers
{
    public class tblProveedoresController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();
      



        // GET: tblProveedores
        public ActionResult Index()
        {
            var primerProveedor = db.tblProveedores.Include(t => t.tblCategoriasProveedores)
                                                   .Include(t => t.tblEstados)
                                                   .Include(t => t.tblMunicipios)
                                                   .FirstOrDefault();

            return View(primerProveedor);
        }





        // GET: tblProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedores tblProveedores = db.tblProveedores.Find(id);
            if (tblProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedores);
        }

        // GET: tblProveedores/Create
        public ActionResult Create()
        {
            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria");
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado");
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio");
            return View();
        }

        // POST: tblProveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProveedor,nomNegocio,idCategoriaProveedor,sitioWeb,tel,email,codigoPostal,direccion,pais,idEstado,idMunicipio,precioInicial,password")] tblProveedores tblProveedores)
        {
            if (ModelState.IsValid)
            {
                // Crear un nuevo usuario
                tblUsuarios nuevoUsuario = new tblUsuarios();
                nuevoUsuario.nombre = tblProveedores.nomNegocio;
                nuevoUsuario.email = tblProveedores.email;
                nuevoUsuario.password = tblProveedores.password;
                nuevoUsuario.tipoUsuarioID = 1; //O el que le corresponda al tipo de usuario proveedores

                // Agregar el nuevo usuario al contexto
                db.tblUsuarios.Add(nuevoUsuario);

                // Guardar cambios en la base de datos para obtener un usuarioID válido
                db.SaveChanges();

                // Asignar el usuarioID generado al proveedor
                tblProveedores.usuarioID = nuevoUsuario.usuarioID;

                // Agregar el proveedor al contexto
                db.tblProveedores.Add(tblProveedores);

                // Guardar cambios en la base de datos
                db.SaveChanges();

                // Redirigir al usuario a la página principal
                return RedirectToAction("Index");
            }

            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria", tblProveedores.idCategoriaProveedor);
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblProveedores.idEstado);
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio", tblProveedores.idMunicipio);
            return View(tblProveedores);
        }


      

        // GET: tblProveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedores tblProveedores = db.tblProveedores.Find(id);
            if (tblProveedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria", tblProveedores.idCategoriaProveedor);
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblProveedores.idEstado);
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio", tblProveedores.idMunicipio);
            return View(tblProveedores);
        }

        // POST: tblProveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProveedor,nomNegocio,idCategoriaProveedor,sitioWeb,tel,email,codigoPostal,direccion,pais,idEstado,idMunicipio,precioInicial")] tblProveedores tblProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoriaProveedor = new SelectList(db.tblCategoriasProveedores, "idCategoriaProveedor", "nombreCategoria", tblProveedores.idCategoriaProveedor);
            ViewBag.idEstado = new SelectList(db.tblEstados, "idEstado", "nombreEstado", tblProveedores.idEstado);
            ViewBag.idMunicipio = new SelectList(db.tblMunicipios, "idMunicipio", "nombreMunicipio", tblProveedores.idMunicipio);
            return View(tblProveedores);
        }

        // GET: tblProveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProveedores tblProveedores = db.tblProveedores.Find(id);
            if (tblProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedores);
        }

        // POST: tblProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProveedores tblProveedores = db.tblProveedores.Find(id);
            db.tblProveedores.Remove(tblProveedores);
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


  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Busca al proveedor por su email y contraseña
                var proveedor = db.tblUsuarios.FirstOrDefault(p => model.Email== p.email  && model.Password == p.password );

                if (proveedor != null)
                {
                    // Autentica al proveedor
                    FormsAuthentication.SetAuthCookie(proveedor.email, false);
                    return RedirectToAction("Index"); // Redirige al usuario después de iniciar sesión
                }
                else
                {
                    ModelState.AddModelError("", "El email o la contraseña es incorrecto.");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Create", "tblProveedores");
        }



    }
}
