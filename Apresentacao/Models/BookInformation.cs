using AMBEV.AS.Utils.Extensions;
using Entities;

namespace Apresentacao.Models
{
    public class BookInformation : BookBE
    {
        public string BookInfo => $"{Title} - {Author} - {Genre.GetStringValue()}";
    }
}