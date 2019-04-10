using NewsAPI.Models;
using Newtonsoft.Json;
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
            var models = new List<JsonElement>();
            var jsonTask = Factory.Instance.GetJSONPlaceholderRecordsAsync();
            jsonTask.ContinueWith((task) =>
            {
                models = JsonConvert.DeserializeObject<List<JsonElement>>(task.Result);
                return View(models);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            jsonTask.ContinueWith((task) =>
            {
                var error = task.Result;
            }, TaskContinuationOptions.OnlyOnFaulted);
            return View();
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