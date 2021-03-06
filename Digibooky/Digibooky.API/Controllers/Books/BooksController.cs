﻿using Digibooky.API.Controllers.Books.Interfaces;
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
        public ActionResult<BookDTODetails> ShowDetailsOfSingleBook(string ISBN)
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
        public ActionResult<List<BookDTODetails>> SearchByTitle([FromRoute]string title)
        {
            var books = _bookService.FindAllBooks_SearchByTitle(title);
            if (books.Count == 0)
            { return NotFound("No items found"); }
            else
            { return Ok(_bookMapper.ListofBookToDTOList(books)); }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("[action]/{ISBN}")]
        public ActionResult<List<BookDTODetails>> SearchByISBN([FromRoute]string ISBN)
        {
            var books = _bookService.FindAllBooks_SearchByISBN(ISBN);
            if (books.Count == 0)
            { return NotFound("No items found"); }
            else
            { return Ok(_bookMapper.ListofBookToDTOList(books)); }
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("[action]/{author}")]
        public ActionResult<List<BookDTODetails>> SearchByAuthor([FromRoute]string author)
        {
            var books = _bookService.FindAllBooks_SearchByAuthor(author);
            if (books.Count == 0)
            { return NotFound("No items found"); }
            else
            { return Ok(_bookMapper.ListofBookToDTOList(books)); }
        }

        [Authorize(Policy = "MustBeAdmin")]
        [HttpPost]
        public ActionResult<Book> RegisterABook([FromBody] BookDTORegister bookDTORegister)
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

		[Authorize(Policy = "MustBeAdmin")]
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

        [Authorize(Policy = "MustBeAdmin")]
        [HttpDelete]
        [Route("[action]/{ISBN}")]
        public ActionResult<Book> Delete([FromRoute]string ISBN)
        {
            _bookService.Delete(ISBN);
            return Ok();
        }

        [Authorize(Policy = "MustBeAdmin")]
        [HttpPut]
        [Route("[action]/{ISBN}")]
        public ActionResult<Book> Restore([FromRoute]string ISBN)
        {
            _bookService.Restore(ISBN);
            return Ok();
        }

        [Authorize(Policy = "MustBeLibrarian")]
        [HttpGet]
        [Route("Overdue")]
        public ActionResult<List<OverdueBookDTO>> GetAllOverdueBooks()
        {
            return Ok(_bookMapper.ListOfOverdueBookToDTOList(_bookService.GetAllOverdueBooks()));
        }

    }
}