using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Books
{
    public class BookDetailsDTO
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int IDAuthor { get; set; }
        public string FirstNameAuthor { get; set; }
        public string LastNameAuthor { get; set; }
    }
}
