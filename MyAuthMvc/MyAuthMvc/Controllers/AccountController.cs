using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyAuthMvc.Models;
using MyAuthMvc.ModelViews;

namespace MyAuthMvc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel avm, string returnUrl = "")
        {
            var am = new MyAccountManager();

            if (!ModelState.IsValid || string.IsNullOrEmpty(avm.Username)
                || string.IsNullOrEmpty(avm.Password)
                || am.Find(avm.Username, avm.Password) == null)
            {
                ViewBag.Error = "Account credentials are invalid";
                return View("Login");
            }

            FormsAuthentication.SetAuthCookie(avm.Username, avm.RememberMe);
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index","Profile");

            }

            
       
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
           FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }


    }
}