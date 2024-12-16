using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IAB_MVC_V1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            //Ruta para la búsqueda de lugares
            routes.MapRoute(
                name: "BanquetesBoda",
                url: "BanquetesBoda",
                defaults: new { controller = "Banquetes", action = "BanquetesBoda" }
            );

            //Ruta para login
            routes.MapRoute(
            name: "Login",
            url: "Login",
            defaults: new { controller = "Login", action = "LoginUser" }
           );

            //Ruta Inicio Principal
            routes.MapRoute(
                name:"DashboardInicio",
                url: "Inicio",
                defaults: new { controller="Dashboardinicio", action="Inicio"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
