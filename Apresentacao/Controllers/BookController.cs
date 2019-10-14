using BO;
using Entities;
using System.Web.Mvc;
using System.Linq;
using AMBEV.AS.Utils.Tools;
using AMBEV.AS.Utils.Enum;

namespace Apresentacao.Controllers
{
    public class BookController : Controller
    {

        public ActionResult Index()
        {
            var bookBO = new BookBO();
            ViewBag.BooksList = bookBO.BookList();
            return View();
        }

        public ActionResult Edit(BookBE bookBE)
        {
            BookBO bookBO = new BookBO();           
            bookBO.EditBook(bookBE);
            return RedirectToAction("Index", "Book");
        }

        public ActionResult OpenEdit(int id)
        {
            BookBO bookBO = new BookBO();
            var book = bookBO.GetBookById(id);
            ViewBag.EnumGenreList = new SelectList(EnumHelper.GetDictionary<GenreEnum>(), "Key", "Value");
            return View("Edit", book);
        }

        public ActionResult Add(BookBE bookBE)
        {
            BookBO bookBO = new BookBO();
            bookBO.AddBook(bookBE);
            return RedirectToAction("Index", "Book");
        }

        public ActionResult OpenAdd()
        {
            ViewBag.EnumGenreList = new SelectList(EnumHelper.GetDictionary<GenreEnum>(), "Key", "Value");

            return View("Add");
        }


        public ActionResult Delete(BookBE bookBE)
        {
            BookBO bookBO = new BookBO();
            bookBO.DeleteBook(bookBE);
            return RedirectToAction("Index", "Book");
        }

        //public ActionResult Borrow(int id)
        //{
        //    return View();
        //}

        //public ActionResult Book(int id)
        //{
        //    return View();
        //}             

    }
}