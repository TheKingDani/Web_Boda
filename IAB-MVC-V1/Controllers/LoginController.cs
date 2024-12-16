using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IAB_MVC_V1.Models;
using IAB_MVC_V1.ViewModels;

namespace IAB_MVC_V1.Controllers
{
    public class LoginController : Controller
    {
        private dbInvitacionBodaEntities db = new dbInvitacionBodaEntities();

        //formulario login
        [HttpGet]
        public ActionResult LoginUser()
        {
            return View("Login");
        }

        //proceso login
        [HttpPost]
        public ActionResult LoginUser(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Por favor, completa todos los Campos correctamente.";
                return View("Login", model);
            }

            //Busca el usario a db
            var usuario = db.tblUsuarios
               .FirstOrDefault(u => u.email == model.Email && u.password == model.Password);

            if (usuario == null)
            {
                // Usuario no encontrado
                ViewBag.ErrorMessage = "Credenciales incorrectas.";
                return View("Login", model);
            }

            // Redirección según el tipo de usuario
            switch (usuario.tipoUsuarioID)
            {
                case 1: // Proveedores
                    return RedirectToAction("index", "tblProveedores");

                case 2: // Novios
                    string destino = Request.QueryString["destino"];
                    if (string.IsNullOrEmpty(destino))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    switch (destino)
                    {
                        case "Home":
                            return RedirectToAction("Index", "Home");
                        case "Novios":
                            return RedirectToAction("Index","tblBioNovios");
                            default:
                            return RedirectToAction("Index", "Home");
                    }

                case 3: // Organizadores
                    return RedirectToAction("Index", "tblOrganizadoresBodas");

                default: // Acceso denegado
                    return RedirectToAction("AccesoNegado", "Error");
            }

        }
    }
}