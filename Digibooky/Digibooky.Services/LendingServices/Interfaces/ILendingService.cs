using Digibooky.Domain.Lendings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Services.LendingServices.Interfaces
{
    public interface ILendingService
    {
        void LendBook(Guid userId, Guid bookId);
        List<Lending> GetAll();
    }
}
