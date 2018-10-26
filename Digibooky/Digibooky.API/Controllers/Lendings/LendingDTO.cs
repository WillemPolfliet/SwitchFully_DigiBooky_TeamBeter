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
        public DateTime Date { get; set; }
        public DateTime ReturnDate { get; set; }

        public LendingDTO(Lending lending)
        {
            ID = lending.ID;
            Inss = lending.INSS;
            Isbn = lending.Isbn;
            Date = lending.Date;
            ReturnDate = lending.ReturnDate;
        }

    }
}
