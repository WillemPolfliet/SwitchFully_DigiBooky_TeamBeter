using Digibooky.Databases;
using Digibooky.Domain.Lendings;
using System;
using System.Collections.Generic;
using Digibooky.Services.LendingServices.Interfaces;
using System.Text;
using Digibooky.Domain.Lendings.Exceptions;
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

            Lending lending = new Lending(inss, isbn, DateTime.Today.Date, DateTime.Today.Date.AddDays(21));

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

    }
}
