using Digibooky.Domain.Lendings;
using Digibooky.Domain.Users;
using System.Collections.Generic;

namespace Digibooky.Services.LendingServices.Interfaces
{
    public interface ILendingService
    {
        void LendBook(long inss, string isbn);
        List<Lending> GetAll();
        void ReturnBook(string guid);
        string GetLender(string givenISBN);
    }
}
