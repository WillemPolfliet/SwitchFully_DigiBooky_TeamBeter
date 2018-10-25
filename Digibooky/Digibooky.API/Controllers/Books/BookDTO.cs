
using Digibooky.Domain.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Books
{
    public class BookDTO
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }

    }
}
