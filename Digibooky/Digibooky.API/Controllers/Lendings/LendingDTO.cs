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
        Guid UserId { get; set; }
        Guid BookId { get; set; }
        DateTime Date { get; set; }
        DateTime ReturnDate { get; set; }

        public LendingDTO(Lending lending)
        {
            ID = lending.ID;
            UserId = lending.UserId;
            BookId = lending.BookId;
            Date = lending.Date;
            ReturnDate = lending.ReturnDate;
        }

    }
}
