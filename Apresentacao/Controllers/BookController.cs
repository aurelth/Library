using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apresentacao.Controllers
{
    public class BookController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
       

        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Borrow(int id)
        {
            return View();
        }

        public ActionResult Book(int id)
        {
            return View();
        }


    }
}