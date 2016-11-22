using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using MyAuthMvc.Models;
using MyAuthMvc.Security;

namespace MyAuthMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;
        }

        protected void Application_PostAuthenticateRequest()
        {
            var cockie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cockie!= null)
            {
                var ticket = FormsAuthentication.Decrypt(cockie.Value);
                var js = new JavaScriptSerializer();
                var user = js.Deserialize<MyUser>(ticket.UserData);
                var identity = new MyIdentity(user);
                var principal = new MyPrincipal(identity);
                HttpContext.Current.User = principal;
            }
        }
    }
}
