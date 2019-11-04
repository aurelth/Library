using AMBEV.AS.Utils.Enum;
using Entities;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAO
{
    public class BookDAO : BaseDAO<BookDAO>
    {
        public List<BookBE> GetAllBooks()
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            string sql = "SELECT * FROM BOOKS ORDER BY UPPER(TITLE)";

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

            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE BOOKS");            
            sb.Append($" SET TITLE = '{bookBE.Title}',");
            sb.Append($" AUTHOR = '{bookBE.Author}',");
            sb.Append($" GENRE = {(int)bookBE.Genre}");
            sb.Append($" WHERE ID = {bookBE.Id}");

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }

        public void AlterBookStatus(BookBE bookBE)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE BOOKS");
            sb.Append($" SET STATUS = {bookBE.Status}");
            sb.Append($" WHERE ID = {bookBE.Id} ");

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }

        public void AddBook(BookBE bookBE)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO BOOKS");
            sb.Append("(ID, TITLE, AUTHOR, GENRE) ");
            sb.Append("VALUES");
            sb.Append($"(SQ_BOOKS.NEXTVAL, '{bookBE.Title}', '{bookBE.Author}', {(int)bookBE.Genre})");

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }

        public void DeleteBook(BookBE bookBE)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM BOOKS");
            sb.Append($" WHERE ID = {bookBE.Id}");

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }        
        
        public BookBE GetBookById(int id)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            string sql = @"SELECT *
                            FROM BOOKS
                            WHERE ID = " + id;

            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            BookBE book = new BookBE();
            while (dr.Read())
            {                
                book.Id = ObterValor<long>(dr["ID"]);
                book.Title = ObterValor<string>(dr["TITLE"]);
                book.Author = ObterValor<string>(dr["AUTHOR"]);
                book.Genre = (GenreEnum)ObterValor<int>(dr["GENRE"]);               
            }

            conn.Dispose();

            return book;
        }
    }    
}

