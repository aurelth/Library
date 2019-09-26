using DAO;
using Entities;
using System;
using System.Collections.Generic;

namespace BO
{
    public class BookBO
    {
        public List<BookBE> BookList()
        {
            return BookDAO.GetInstance().GetAllBooks();
        }
    }
}
