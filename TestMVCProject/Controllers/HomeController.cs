using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestMVCProject.Models;
using TestMVCProject.Proxy;

namespace TestMVCProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var models = string.Empty;
            var jsonTask = Factory.Instance.GetJSONPlaceholderRecordsAsync();
            jsonTask.ContinueWith((task) => {
                var data = task.Result;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            return View(models);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}