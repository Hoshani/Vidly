using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // this will make routing on controller file instead of creating it here
            routes.MapMvcAttributeRoutes();

            // the order of routes matters, you need to range them from the most specefic to the most generic
            // note this approach will create a fragile code
            routes.MapRoute(
                "MoviesByReleaseDate", // Name
                "movies/released/{year}/{month}", // URL with {variables}
                new { controller = "Movies", action = "ByReleaseDate" }, // defaults for map route
                new { year = @"\d{4}", month = @"\d{2}" } // regex to validate parameters
                );

            // this is the default route, if there is no custom route matching it will go here 
            // note: make it the last route because it will skip the rest
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
