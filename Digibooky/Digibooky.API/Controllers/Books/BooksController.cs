﻿using Digibooky.API.Controllers.Books.Interfaces;
using Digibooky.Domain.Books;
using Digibooky.Services.BookServices;
using Digibooky.Services.BookServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Books
{
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

        [HttpGet]
        public ActionResult<List<BookDTO>> GetAllBooks()
        {
            return Ok(_bookMapper.ListofBookToDTOList(_bookService.GetAllBooks()));
        }

        [HttpGet]
        [Route("ShowDetailsOfSingleBook/{ISBN}")]
        public ActionResult<BookDTO> ShowDetailsOfSingleBook(string ISBN)
        {
            try
            {
                var selectedBook = _bookService.GetBookByISBN(ISBN);
                return Ok(_bookMapper.BookToDTO(selectedBook));

            }
            catch (Exception bookEx)
            {
                return BadRequest(bookEx.Message);
            }

        }
    }
}