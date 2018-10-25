using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Authors
{
    public class Author
    {
        public int AuthorId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Author(int authorId, string firstName, string lastName)
        {
            AuthorId = authorId;
            FirstName = firstName;
            LastName = lastName;
        }

        public Author(int authorId)
        {
            AuthorId = authorId;
        }
    }
}
