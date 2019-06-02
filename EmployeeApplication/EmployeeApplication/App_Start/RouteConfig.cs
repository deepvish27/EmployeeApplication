using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmployeeApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authenticate", action = "LoginView", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "RemoveEmployee", 
                "{controller}/{action}/{id}", 
                new { controller = "Home", action = "RemoveEmployee" });

            //routes.MapRoute(
            //    "EditEmployee",
            //    "{controller}/{action}/{id}|{EmployeeFullName}",
            //    new { controller = "Home", action = "EditEmployee" }
            //    );
        }
    }
}
