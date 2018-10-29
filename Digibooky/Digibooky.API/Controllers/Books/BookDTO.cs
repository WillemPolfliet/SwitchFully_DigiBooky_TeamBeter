namespace Digibooky.API.Controllers.Books
{
    public class BookDTO
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
