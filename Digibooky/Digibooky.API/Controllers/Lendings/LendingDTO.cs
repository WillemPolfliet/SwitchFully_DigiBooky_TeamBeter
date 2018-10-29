using Digibooky.Domain.Lendings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Lendings
{
    public class LendingDTO
    {
        public Guid ID { get; set; }
        public long Inss { get; set; }
        public string Isbn { get; set; }
        public string Date { get; set; }
        public string ReturnDate { get; set; }
        public string DateReturned { get; set; }

        public LendingDTO(Lending lending)
        {
            ID = lending.ID;
            Inss = lending.INSS;
            Isbn = lending.Isbn;
            Date = lending.Date.ToString();
            ReturnDate = lending.ReturnDate.ToString();
            DateReturned = lending.DateReturned.ToString();
        }

    }
}
