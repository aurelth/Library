using System;

namespace Entities
{
    public class BookingBE
    {
        public int CpfPerson { get; set; }
        public string NamePerson { get; set; }
        public int Phone { get; set; }
        public int BookId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
