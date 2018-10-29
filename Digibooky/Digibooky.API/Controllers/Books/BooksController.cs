using Digibooky.API.Controllers.Books.Interfaces;
using Digibooky.Domain.Books;
using Digibooky.Domain.Books.Exceptions;
using Digibooky.Services.BookServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Digibooky.API.Controllers.Books
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IBookMapper _bookMapper;

        public BooksController(IBookService bookService, IBookMapper bookMapper)
        {
            _bookService = bookService;
            _bookMapper = bookMapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<BookDTO>> GetAllBooks()
        {
            return Ok(_bookMapper.ListofBookToDTOList(_bookService.GetAllBooks()));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{ISBN}")]
        public ActionResult<BookDetailsDTO> ShowDetailsOfSingleBook(string ISBN)
        {
            try
            {
                var selectedBook = _bookService.GetBookByISBN(ISBN);
                return Ok(_bookMapper.BookToDetailsDTO(selectedBook));
            }
            catch (BookException bookEx)
            {
                return BadRequest(bookEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("[action]/{title}")]
        public ActionResult<List<BookDetailsDTO>> SearchByTitle([FromRoute]string title)
        {
            var books = _bookService.FindAllBooks_SearchByTitle(title);
            if (books.Count == 0)
            { return NotFound("No ItemsFound"); }
            else
            { return Ok(books); }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("[action]/{ISBN}")]
        public ActionResult<List<BookDetailsDTO>> SearchByISBN([FromRoute]string ISBN)
        {
            var books = _bookService.FindAllBooks_SearchByISBN(ISBN);
            if (books.Count == 0)
            { return NotFound("No ItemsFound"); }
            else
            { return Ok(books); }
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("[action]/{author}")]
        public ActionResult<List<BookDetailsDTO>> SearchByAuthor([FromRoute]string author)
        {
            var books = _bookService.FindAllBooks_SearchByAuthor(author);
            if (books.Count == 0)
            { return NotFound("No ItemsFound"); }
            else
            { return Ok(books); }
        }

        [Authorize(Roles = "admin, librarian")]
        [HttpPost]
        public ActionResult<Book> Register([FromBody] BookDTORegister bookDTORegister)
        {
            try
            {
                Book book = _bookMapper.BookDTORegisterToBook(bookDTORegister);
                _bookService.Register(book);
                return Ok();
            }
            catch (BookException bookEx)
            {
                return BadRequest(bookEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("[action]/{ISBN}")]
        public ActionResult<Book> UpdateInformation([FromRoute]string ISBN, [FromBody] BookDTOUpdate bookDTOUpdate)
        {
            try
            {
                var title = bookDTOUpdate.Title;
                var authorFirstName = bookDTOUpdate.AuthorFirstName;
                var authorLastName = bookDTOUpdate.AuthorLastName;
                _bookService.UpdateInformation(ISBN, title, authorFirstName, authorLastName);
                return Ok();
            }
            catch (BookException bookEx)
            {
                return BadRequest(bookEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}