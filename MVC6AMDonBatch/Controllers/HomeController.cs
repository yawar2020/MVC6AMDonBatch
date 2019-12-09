using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC6AMDonBatch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult MyHome()
        {
            return View();
        }
    }
}