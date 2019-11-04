using Entities;
using Oracle.DataAccess.Client;
using System.Data;
using System.Text;

namespace DAO
{
    public class BookingDAO : BaseDAO<BookingDAO>
    {        
        public BookingBE GetBookingByBookId(int bookId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM BOOKING");
            sb.Append($" WHERE BOOK_ID = {bookId}");

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            BookingBE bookingBE = new BookingBE();
            while (dr.Read())
            {
                bookingBE.CpfPerson = ObterValor<int>(dr["CPF_PERSON"]);
                bookingBE.NamePerson = ObterValor<string>(dr["NAME_PERSON"]);
                bookingBE.Phone = ObterValor<int>(dr["PHONE"]);
                bookingBE.BookId = ObterValor<int>(dr["BOOK_ID"]);
                bookingBE.BookingDate = ObterValor<System.DateTime>(dr["BOOKING_DATE"]);
            }

            conn.Dispose();
            return bookingBE;
        }

        public void UpdateOrInsertBooking(BookingBE bookingBE)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            StringBuilder sb = new StringBuilder();

            sb.Append(" MERGE INTO BOOKING B ");
            sb.Append($" USING(SELECT {bookingBE.CpfPerson} CPF_PERSON,");
            sb.Append($" {bookingBE.NamePerson} NAME_PERSON,");
            sb.Append($" {bookingBE.Phone} PHONE, ");
            sb.Append($" {bookingBE.BookId} BOOK_ID ");
            sb.Append(" FROM DUAL) D ");
            sb.Append(" ON(B.CPF_PERSON = D.CPF_PERSON) ");
            sb.Append(" WHEN MATCHED THEN ");
            sb.Append(" UPDATE SET B.NAME_PERSON = D.NAME_PERSON, ");
            sb.Append(" B.PHONE = D.PHONE, ");
            sb.Append(" B.BOOKING_DATE = SYSDATE ");
            sb.Append(" WHEN NOT MATCHED THEN ");
            sb.Append(" INSERT(CPF_PERSON, NAME_PERSON, PHONE, BOOK_ID, BOOKING_DATE) ");
            sb.Append(" VALUES(D.CPF_PERSON, D.NAME_PERSON, D.PHONE, D.BOOK_ID, SYSDATE); ");

            OracleCommand cmd = new OracleCommand(sb.ToString(), conn)
            {
                CommandType = CommandType.Text
            };

            cmd.ExecuteNonQuery();
        }
    }
}
