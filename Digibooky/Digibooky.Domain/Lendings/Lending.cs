using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Lendings
{
    public class Lending
    {
        string ID { get; set; }
        Guid UserId { get; set; }
        Guid BookId { get; set; }
        DateTime Date { get; set; }
        DateTime ReturnDate { get; set; }

        public Lending(string id, Guid userId, Guid bookId, DateTime date, DateTime returnDate)
        {
            ID = id;
            UserId = userId;
            BookId = bookId;
            Date = date;
            ReturnDate = returnDate;
        }
    }
}
