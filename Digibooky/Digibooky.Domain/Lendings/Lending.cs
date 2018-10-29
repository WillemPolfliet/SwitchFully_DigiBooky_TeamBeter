using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Lendings
{
    public class Lending
    {
        public Guid ID { get; set; }
        public long INSS { get; set; }
        public string Isbn { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? DateReturned { get; set; }

        public Lending(long inss, string isbn)
        {
            ID = Guid.NewGuid();
            INSS = inss;
            Isbn = isbn;
            Date = DateTime.Now.Date;
            ReturnDate = DateTime.Now.Date.AddDays(21);
            DateReturned = null;
        }
    }
}
