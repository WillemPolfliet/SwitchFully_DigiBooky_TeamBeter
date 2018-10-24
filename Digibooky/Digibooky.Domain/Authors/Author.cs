using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Authors
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
