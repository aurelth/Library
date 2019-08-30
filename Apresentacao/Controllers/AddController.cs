using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apresentacao.Controllers
{
    public class AddController : Controller
    {
        // GET: Add
        public ActionResult Index()
        {
            return Content("I've just created another controller.");
        }
        public ActionResult AddBook(int id)
        {
            return Content("Add a book with the id " + id);
        }
    }
}