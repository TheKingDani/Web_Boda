using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAB_MVC_V1.Controllers
{
    public class DashboardinicioController : Controller
    {
        // GET: Dashboardinicio
        public ActionResult Inicio()
        {
            ViewBag.Message = "Bienvenido al Dashboard de Incio";
            return View();
        }
    }
}