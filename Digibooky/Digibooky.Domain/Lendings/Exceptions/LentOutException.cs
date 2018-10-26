using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Lendings.Exceptions
{
    public class LentOutException : Exception
    {
        public LentOutException(string message) : base(message)
        {
        }
    }
}
