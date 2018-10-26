using Digibooky.Domain.Lendings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Services.LendingServices.Interfaces
{
    public interface ILendingService
    {
        void LendBook(long inss, string isbn);
        List<Lending> GetAll();
    }
}
