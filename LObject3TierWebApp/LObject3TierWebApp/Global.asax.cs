using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LObject3TierWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Можно заблокировать автоматическую проверку модели здесь.. 
            //но придется открыть доступ к DAL (нарушение изоляции слоёв)
            //Database.SetInitializer<ApplicationDbContext>(null);
        }
    }
}
