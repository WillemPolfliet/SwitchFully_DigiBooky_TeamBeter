using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Books
{
    public class BookDTODetails
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string FirstNameAuthor { get; set; }
        public string LastNameAuthor { get; set; }
        public bool BookIsLent { get; set; }
        public string Lender { get;set; }
    }
}
