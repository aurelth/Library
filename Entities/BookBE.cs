using AMBEV.AS.Utils.Enum;
using Shared.Enums;

namespace Entities
{
    public class BookBE
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public GenreEnum Genre { get; set; }
        public StatusEnum Status { get; set; }
    }
}
