using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Books.Exceptions
{
    public class BookException : Exception
    {
        public BookException(string message) : base(message)
        {
        }
    }
}
