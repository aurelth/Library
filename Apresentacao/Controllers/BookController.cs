using AMBEV.AS.Utils.Enum;
using AMBEV.AS.Utils.Tools;
using BO;
using Entities;
using Shared.Enums;
using System.Web.Mvc;

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
       

        public ActionResult Book(int bookId)
        {
            BookingBO bookingBO = new BookingBO();
            var bookingBE = bookingBO.GetBookingByBookId(bookId);
            return View("Book", bookingBE);           
        }
        public ActionResult UpdateOrInsertBooking(BookingBE bookingBE)
        {
            var bookingBO = new BookingBO();
            var bookBO = new BookBO();
            bookingBO.UpdateOrInsertBooking(bookingBE);
            var book = bookBO.GetBookById(bookingBE.BookId);
            book.Status = StatusEnum.Occupied;
            bookBO.AlterBookStatus(book);
            return RedirectToAction("Index", "Book");
        }        
    }
}

