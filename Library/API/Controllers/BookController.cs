﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("Books")]
    [EnableCors("Policy")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IBookService _bookService;

        public BookController(IUserManager userManager, IBookService bookService)
        {
            _bookService = bookService;
            _userManager = userManager;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<Book[]> GetBooks()
        {
            var identity = (ClaimsIdentity) this.User.Identity;
            var userEmail = identity.FindFirst(JwtRegisteredClaimNames.Sub).Value;
            var user = await _userManager.GetUserByEmail(userEmail);
            IEnumerable<Book> userBookList = _bookService.GetAll(user.Id);
            Book[] books = userBookList.ToArray();
            return books;
        }

        [Route("Get")]
        [HttpGet("{id}")]
        public Book GetBook(int id)
        {
            return _bookService.GetBook(id);
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult<Book> UpdateBook(Book book)
        {
            if (book != null)
            {
                Book actualBook = _bookService.GetBook(book.BookId);
                actualBook.Title = book.Title;
                actualBook.Content = book.Content;
                _bookService.Update(actualBook);
                return actualBook;
            }

            return null;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            if (book.Content != null)
            {
                var identity = (ClaimsIdentity) this.User.Identity;

                var currentUserName = identity.FindFirst(JwtRegisteredClaimNames.Sub).Value;
                var user = await _userManager.GetUserByEmail(currentUserName);
                book.AuthorId = user.Id.ToString();
                book.ReleaseDate = DateTime.Now;
                _bookService.Create(book);
                return Ok(book);
            }

            return BadRequest("hui");
        }

        [Route("Delete/{id}")]
        [HttpPost]
        public int DeleteBook(int id)
        {
            var book = _bookService.GetBook(id);
            _bookService.Delete(book);

            return id;
        }

    }
}