using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LObject3Tier.BLL.Infrastructure;
using LObject3Tier.BLL.Interfaces;
using LObject3Tier.BLL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(LObject3TierWebApp.App_Start.Startup))]

namespace LObject3TierWebApp.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();

        //public Startup(IUserService userService)
        //{
        //    _userService = userService;
        //}

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}