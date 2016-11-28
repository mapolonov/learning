using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using LObjectWebApp.ViewModels;

namespace LObjectWebApp.Controllers
{
    public class AccountController : Controller
    {
        //// GET: Account
        //[RequireHttps]
        //[AllowAnonymous]
        //public ActionResult Login()
        //{
        //    return View("Login");
        //}

        //[HttpPost]
        //[RequireHttps]
        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]
        //public ActionResult Login(LoginViewModel avm, string returnUrl = "")
        //{
        //    //var am = new MyUserManager();

        //    if (!ModelState.IsValid || !Membership.ValidateUser(avm.Username, avm.Password))
        //    {
        //        ViewBag.Error = "Account credentials are invalid";
        //        return View("Login");
        //    }

        //    var user = am.Find(avm.Username, avm.Password);
        //    var js = new JavaScriptSerializer();
        //    var data = js.Serialize(user);
        //    var ticket = new FormsAuthenticationTicket(1, avm.Username, DateTime.Now, DateTime.Now.AddMinutes(30), avm.RememberMe, data);
        //    var encToken = FormsAuthentication.Encrypt(ticket);
        //    var cockie = new HttpCookie(FormsAuthentication.FormsCookieName, encToken);
        //    Response.Cookies.Add(cockie);


        //    //FormsAuthentication.SetAuthCookie(avm.Username, avm.RememberMe);
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Profile");

        //    }



        //}

        //[Authorize]
        //[HttpPost]
        //[RequireHttps]
        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Login", "Account");
        //}


    }
}