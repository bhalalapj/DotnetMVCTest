using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Article> models = Factory.Instance.GetLatestNews();
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