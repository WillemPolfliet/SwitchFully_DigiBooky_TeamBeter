using Digibooky.Domain.Books;
using Digibooky.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Services.BookServices.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Dictionary<Book,string> GetBookByISBN(string givenISBN);
        void Register(Book bookToRegister);
        List<Book> FindAllBooks_SearchByTitle(string givenMatchingString);
        List<Book> FindAllBooks_SearchByISBN(string givenMatchingString);
        List<Book> FindAllBooks_SearchByAuthor(string givenMatchingString);
        void UpdateInformation(string iSBN, string title, string authorFirstName, string authorLastName);
        void Delete(string iSBN);
        void Restore(string iSBN);
        List<OverdueBook> GetAllOverdueBooks();

    }
}
