using DAO;
using Entities;
using System.Collections.Generic;

namespace BO
{
    public class BookBO
    {
        public List<BookBE> BookList()        
            => BookDAO.GetInstance().GetAllBooks();        

        public void EditBook(BookBE bookBE)        
            =>BookDAO.GetInstance().EditBook(bookBE);        

        public BookBE GetBookById(int id)
            => BookDAO.GetInstance().GetBookById(id);

        public void AddBook(BookBE bookBE)
            => BookDAO.GetInstance().AddBook(bookBE);

        public void DeleteBook(BookBE bookBE)
            => BookDAO.GetInstance().DeleteBook(bookBE);

        public void AlterBookStatus(BookBE bookBE)
            => BookDAO.GetInstance().AlterBookStatus(bookBE);
    }
}
