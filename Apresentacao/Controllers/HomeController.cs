using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index()
        {
            ViewBag.library = "Creating a library for my first ASP.Net project.";
            return View();
        }
    }
}