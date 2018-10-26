using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Lendings
{
    public class Lending
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReturnDate { get; set; }

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
