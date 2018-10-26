using Digibooky.Databases;
using Digibooky.Domain.Lendings;
using System;
using System.Collections.Generic;
using Digibooky.Services.LendingServices.Interfaces;
using System.Text;

namespace Digibooky.Services.LendingServices
{
    public class LendingService : ILendingService
    {
        public void LendBook(long inss, string isbn)
        {
            Lending lending = new Lending(inss, isbn, DateTime.Today.Date, DateTime.Today.Date.AddDays(21));

            LendingsDatabase.Lendings.Add(lending);
        }

        public List<Lending> GetAll()
        {
            return LendingsDatabase.Lendings;
        }
    }
}
