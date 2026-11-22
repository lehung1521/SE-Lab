using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentsApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Forms authentication khong co claim NameIdentifier -> dung username cho anti-forgery token
            AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
