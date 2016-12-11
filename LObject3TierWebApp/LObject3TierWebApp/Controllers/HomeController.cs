using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LObject3TierWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public async Task<ActionResult> About()
        //{
        //    //await Sleep();
        //    ViewBag.Message = "LObject System Description.";
        //    return View(await Sleep());
        //}

        public ActionResult About()
        {
            ViewBag.Message = "LObject System Description.";
            new WebClient().DownloadString("https://jsonplaceholder.typicode.com/photos");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "LObject Contacts.";

            return View();
        }

        private async Task Sleep()
        {
            var tcs = new TaskCompletionSource<bool>();
            //Thread.Sleep(5000);
            tcs.TrySetResult(true);

           await new WebClient().DownloadStringTaskAsync("https://jsonplaceholder.typicode.com/photos");

            //if (await Task.WhenAny(tcs.Task, Task.Delay(5000)) == tcs.Task)
            //{
            //    // task completed within timeout
            //}
            //else
            //{
            //    // timeout logic
            //}
            //return true;
        }
    }
}