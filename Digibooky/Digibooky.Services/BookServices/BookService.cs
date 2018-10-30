using Digibooky.Databases;
using Digibooky.Domain.Books;
using Digibooky.Domain.Books.Exceptions;
using Digibooky.Services.BookServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Digibooky.Services.BookServices
{
    public class BookService : IBookService
    {
        public List<Book> GetAllBooks()
        {
            return BooksDatabase.booksDb.Where(book => book.IsDeleted == false).ToList();
        }

        public Book GetBookByISBN(string givenISBN)
        {
            var selectedBook = BooksDatabase.booksDb.FirstOrDefault(book => book.ISBN == givenISBN && book.IsDeleted == false);
            if (selectedBook == null)
            { throw new BookException("This ISBN can not be found"); }
            else
            { return selectedBook; }
        }

        public void Register(Book bookToRegister)
        {
            BooksDatabase.booksDb.Add(bookToRegister);
        }


        public List<Book> FindAllBooks_SearchByTitle(string givenMatchingString)
        {
            return FindAllBooks(givenMatchingString, book => book.Title.ToLower().Contains(givenMatchingString.ToLower()));
        }
        public List<Book> FindAllBooks_SearchByISBN(string givenMatchingString)
        {
            return FindAllBooks(givenMatchingString, book => book.ISBN.Contains(givenMatchingString));
        }
        public List<Book> FindAllBooks_SearchByAuthor(string givenMatchingString)
        {
            return FindAllBooks(givenMatchingString,
                book => (book.AuthorFirstName + book.AuthorLastName).ToLower().Contains(givenMatchingString.ToLower()));
        }

        private List<Book> FindAllBooks(string givenMatchingString, Predicate<Book> ValueToCheck)
        {
            List<Book> listToReturn = new List<Book>();

            foreach (var book in BooksDatabase.booksDb)
            {
                if (ValueToCheck(book) && book.IsDeleted == false)
                {
                    listToReturn.Add(book);
                }
            }
            return listToReturn;
        }

        public void UpdateInformation(string iSBN, string title, string authorFirstName, string authorLastName)
        {
            var doesBookExist = BooksDatabase.booksDb.Any(dbBook => dbBook.ISBN == iSBN);

            if (doesBookExist)
            {
                if (!string.IsNullOrWhiteSpace(title))
                {
                    BooksDatabase.booksDb.First(dbBook => dbBook.ISBN == iSBN)
                         .Title = title;
                }
                if(!string.IsNullOrWhiteSpace(authorFirstName))
                {
                    BooksDatabase.booksDb.First(dbBook => dbBook.ISBN == iSBN)
                         .AuthorFirstName = authorFirstName;
                }
                if (!string.IsNullOrWhiteSpace(authorLastName))
                {
                    BooksDatabase.booksDb.First(dbBook => dbBook.ISBN == iSBN)
                         .AuthorLastName = authorLastName;
                }
            }
            else
            {
                throw new BookException("This book does not exist in our database");
            }
        }

        public void Delete(string iSBN)
        {
            BooksDatabase.booksDb.FirstOrDefault(book => book.ISBN == iSBN).IsDeleted = true;
        }

        public void Restore(string iSBN)
        {
            BooksDatabase.booksDb.FirstOrDefault(book => book.ISBN == iSBN).IsDeleted = false;
        }
    }
}
