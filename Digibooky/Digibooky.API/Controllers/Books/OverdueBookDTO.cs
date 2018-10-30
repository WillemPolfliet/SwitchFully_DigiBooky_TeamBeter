﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Books
{
    public class OverdueBookDTO
    {
        public Guid BookId { get; }
        public string Isbn { get; private set; }
        public string Title { get; set; }

        public Guid LendingID { get; set; }
        public long INSS { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? DateReturned { get; set; }

        public string userEmail { get; set; }

        public OverdueBookDTO(Guid bookId, string isbn, string title, Guid lendingID, long iNSS, DateTime date, DateTime returnDate, DateTime? dateReturned, string userEmail)
        {
            BookId = bookId;
            Isbn = isbn;
            Title = title;
            LendingID = lendingID;
            INSS = iNSS;
            Date = date;
            ReturnDate = returnDate;
            DateReturned = dateReturned;
            this.userEmail = userEmail;
        }
    }
}
