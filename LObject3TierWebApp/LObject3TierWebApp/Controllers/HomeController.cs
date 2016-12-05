using System.Web.Mvc;

namespace LObject3TierWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "LObject System Description.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "LObject Contacts.";

            return View();
        }
    }
}