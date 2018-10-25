using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Lendings
{
    public class Lending
    {
        Guid ID { get; set; }
        Guid UserId { get; set; }
        Guid BookId { get; set; }
        DateTime Date { get; set; }
        DateTime ReturnDate { get; set; }

        public Lending(Guid userId, Guid bookId, DateTime date, DateTime returnDate)
        {
            ID = Guid.NewGuid();
            UserId = userId;
            BookId = bookId;
            Date = date;
            ReturnDate = returnDate;
        }
    }
}
