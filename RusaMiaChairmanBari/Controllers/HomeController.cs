using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RusaMiaChairmanBari.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Rusa mia Chairman Bari is best home in laksmipur district";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Rusa mia Chairman bari contact page.";

            return View();
        }
    }
}