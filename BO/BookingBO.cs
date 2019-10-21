using DAO;
using Entities;
using System;

namespace BO
{
    public class BookingBO
    {
        public void UpdateOrInsertBooking(BookingBE bookingBE)
          => BookingDAO.GetInstance().UpdateOrInsertBooking(bookingBE);

        public BookingBE GetBookingByBookId(int bookId)
          => BookingDAO.GetInstance().GetBookingByBookId(bookId);
    }
}
