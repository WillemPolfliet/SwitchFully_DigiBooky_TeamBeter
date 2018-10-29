using Digibooky.Databases;
using Digibooky.Domain.Lendings;
using Digibooky.Domain.Lendings.Exceptions;
using Digibooky.Services.LendingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digibooky.Services.LendingServices
{
    public class LendingService : ILendingService
    {
        public void LendBook(long inss, string isbn)
        {
            if (!DoesUserINSSExist(inss))
            {
                throw new LendingException("User INSS does not exist");//TODO UserException?
            }
            if (!DoesBookISBNExist(isbn))
            {
                throw new LendingException("Book ISBN does not exist");//TODO BookException?
            }
            if (BookIsAlreadyLent(isbn))
            {
                throw new LentOutException("Book is currently not available, it is already lent out.");
            }

            Lending lending = new Lending(inss, isbn);

            LendingsDatabase.Lendings.Add(lending);
        }

        private bool BookIsAlreadyLent(string isbn)
        {
            return LendingsDatabase.Lendings.Any(lending => lending.Isbn == isbn);
        }

        private bool DoesBookISBNExist(string isbn)
        {
            return BooksDatabase.booksDb.Any(book => book.Isbn == isbn);
        }

        private bool DoesUserINSSExist(long inss)
        {
            return UsersDatabase.users.Any(user => user.INSS == inss);
        }

        public List<Lending> GetAll()
        {
            return LendingsDatabase.Lendings;
        }

        public void ReturnBook(string guid)
        {

            var BookToReturn = LendingsDatabase.Lendings.FirstOrDefault(LendBook => LendBook.ID.ToString() == guid);

            if (BookToReturn == null)
            {
                throw new LendingException("Lend does not excist");
            }

            BookToReturn.DateReturned = DateTime.Now.Date;

            if (BookToReturn.DateReturned > BookToReturn.ReturnDate)
            { throw new LentOutException("Lend is overdue"); }

        }
    }
}
