using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVCProject.Models;

namespace TestMVCProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SampleModel> models = new List<SampleModel>();
            for (int i = 0; i < 10; i++)
            {
                models.Add(new SampleModel
                {
                    Name = "Name " + (i+1),
                    Address = "Address " + (i+1)
                });
            }
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