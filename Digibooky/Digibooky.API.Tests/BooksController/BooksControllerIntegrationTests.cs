using Digibooky.API.Controllers.Books;
using Digibooky.Databases;
using Digibooky.Domain.Books;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace Digibooky.API.Tests.BooksController
{
    public class BooksControllerIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public BooksControllerIntegrationTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            BooksDatabase.booksDb.Clear();

            var temp = new List<Book>()
                {
                    new Book("9789024555147", "Het Franciscus Verbond", "John", "Sack"),
                    new Book("9789028418028", "Wereldbibliotheekreeks Verloren eer", "Calixthe", "Beyala"),
                    new Book("9789021006536", "Drie weken in Parijs", "Barbara", "Bradford Taylor"),
                    new Book("9789063050184", "Icy Sparks", "Gwyn", "Hyman Rubio")
                };

            BooksDatabase.booksDb.AddRange(temp);
        }

        [Fact]
        public async Task GetAllBooks_WhenGivenAListOfBook_ThenAllBooksAreReturned()
        {
            var response = await _client.GetAsync("/api/books");
            var responseString = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<BookDTO>>(responseString);

            Assert.True(response.IsSuccessStatusCode);

            Assert.Equal(4, books.Count);
        }

        [Fact]
        public async Task GetSpecificBookByValidISBN_WhenGiveListOfBook_ThenReturnSpecificBook()
        {
            var response = await _client.GetAsync($"/api/books/{BooksDatabase.booksDb[0].ISBN}");
            var responseString = await response.Content.ReadAsStringAsync();
            var bookDTO = JsonConvert.DeserializeObject<BookDTO>(responseString);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(BooksDatabase.booksDb[0].ISBN, bookDTO.Isbn);
        }

        [Fact]
        public async Task GetSpecificBookByiNValidISBN_WhenGiveListOfBook_ThenReturnSpecificBook()
        {
            var response = await _client.GetAsync("/api/books/12345");

            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
