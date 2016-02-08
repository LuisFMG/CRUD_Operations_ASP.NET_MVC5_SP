using System.Web.Mvc;
using System.Web.Routing;

namespace CRUD_Operations_ASP.NET_MVC5_SP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "SearchEmployee", id = UrlParameter.Optional }
            );
        }
    }
}