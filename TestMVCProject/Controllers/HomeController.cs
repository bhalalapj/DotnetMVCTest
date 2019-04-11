using NewsAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public async Task<ActionResult> Index()
        {
            var strJsonResult = await Factory.Instance.GetJSONPlaceholderRecordsAsync();
            var strNasaResult = await Factory.Instance.GetNASAAPIResultAsync();
            dynamic model = new ExpandoObject();
            var models = JsonConvert.DeserializeObject<List<JsonElement>>(strJsonResult);
            var nasaModel = JsonConvert.DeserializeObject<NASAElement>(strNasaResult);
            model.jsonModel = models;
            model.NasaModel = nasaModel;

            return View(model);
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

        public ActionResult Detail(JsonElement ele)
        {
            return View(ele);
        }

        public ActionResult NasaDetail(NASAElement nasaElement)
        {
            return View(nasaElement);
        }
    }
}