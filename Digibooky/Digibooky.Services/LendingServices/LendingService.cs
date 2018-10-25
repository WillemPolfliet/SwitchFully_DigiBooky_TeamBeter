using Digibooky.Databases;
using Digibooky.Domain.Lendings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Services.LendingServices
{
    public class LendingService
    {
        public void LendBook(Guid userId, Guid bookId)
        {

            Lending lending = new Lending(userId, bookId, DateTime.Today.Date, DateTime.Today.Date.AddDays(21));

            LendingsDatabase.Lendings.Add(lending);

        }
    }
}
