using Digibooky.Domain.Lendings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Lendings
{
    public class LendingDTO
    {
        Guid ID { get; set; }
        long Inss { get; set; }
        string Isbn { get; set; }
        DateTime Date { get; set; }
        DateTime ReturnDate { get; set; }

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
