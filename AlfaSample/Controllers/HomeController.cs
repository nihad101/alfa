using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlfaSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Client View";

            return View();
        }

        public ActionResult Invoice()
        {
            ViewBag.Message = "Invoice View";

            return View();
        }

        public ActionResult InvoiceChart()
        {
            ViewBag.Message = "InvoiceChart View";

            return View();
        }
    }   
}
