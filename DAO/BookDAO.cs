using Entities;
using Shared.Enums;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Text;

namespace DAO
{
    public class BookDAO : BaseDAO<BookDAO>
    {

        public List<BookBE> GetAllBooks()
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            string sql = "SELECT * FROM BOOKS";

            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            List<BookBE> books = new List<BookBE>();
            while (dr.Read())
            {
                BookBE book = new BookBE();

                book.Id = ObterValor<long>(dr["ID"]);
                book.Title = ObterValor<string>(dr["TITLE"]);
                book.Author = ObterValor<string>(dr["AUTHOR"]);
                book.Genre = (GenreEnum) ObterValor<int>(dr["GENRE"]);

                books.Add(book);
            }

            conn.Dispose();

            return books;
        }
        public void EditBook(BookBE bookBE)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE BOOKS");
            builder.Append($" SET TITLE = {bookBE.Title}");
            builder.Append($" SET AUTHOR = {bookBE.Author}");
            builder.Append($" SET GENRE = {bookBE.Genre}");
            builder.Append($" WHERE SET ID = {bookBE.Id}");
            builder.Append(" COMMIT");

            OracleCommand cmd = new OracleCommand(builder.ToString(), conn);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }
    }
}
