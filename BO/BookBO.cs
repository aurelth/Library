using DAO;
using Entities;
using System;
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
               
    }
}
