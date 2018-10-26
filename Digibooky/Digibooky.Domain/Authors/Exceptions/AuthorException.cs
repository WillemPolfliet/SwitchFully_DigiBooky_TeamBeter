using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Authors.Exceptions
{
    public class AuthorException : Exception
    {
        public AuthorException(string message) : base(message)
        {
        }
    }
}
