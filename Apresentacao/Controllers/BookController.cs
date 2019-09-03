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

        public ActionResult EditBook(int id)
        {
            return View();
        }
       

        public ActionResult DeleteBook(int id)
        {
            return View();
        }

        public ActionResult BorrowBook(int id)
        {
            return View();
        }

        public ActionResult BookBook(int id)
        {
            return View();
        }


    }
}