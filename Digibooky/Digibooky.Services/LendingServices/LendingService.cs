using Digibooky.Databases;
using Digibooky.Domain.Lendings;
using Digibooky.Domain.Lendings.Exceptions;
using Digibooky.Domain.Users;
using Digibooky.Services.LendingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Digibooky.Services.LendingServices
{
    public class LendingService : ILendingService
    {
        public void LendBook(long inss, string isbn)
        {
            if (!DoesUserINSSExist(inss))
            {
                throw new LendingException("User INSS does not exist");
            }
            if (!DoesBookISBNExist(isbn))
            {
                throw new LendingException("Book ISBN does not exist");
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
            return BooksDatabase.booksDb.Any(book => book.ISBN == isbn && book.IsDeleted == false);
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
                throw new LendingException("Lend does not exist");
            }

            BookToReturn.DateReturned = DateTime.Now.Date;

            if (BookToReturn.DateReturned > BookToReturn.ReturnDate)
            { throw new LentOutException("Lend is overdue"); }

        }

        public string GetLender(string givenISBN)
        {
            if (BookIsAlreadyLent(givenISBN))
            {
                var BookFromLendingDatabase = LendingsDatabase.Lendings.FirstOrDefault(LendBook => LendBook.Isbn == givenISBN);
                var userInss = BookFromLendingDatabase.INSS;
                var user = UsersDatabase.users.FirstOrDefault(usr => usr.INSS == userInss);
                return $"{user.FirstName} {user.LastName}";
            }
            else { return null; }

        }
    }
}
