using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Authors
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

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
