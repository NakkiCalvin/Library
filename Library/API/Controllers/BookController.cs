using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Managers;
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
        public IEnumerable<Book> GetBooks()
        {
            return _bookService.GetAll();
        }

        [Route("Get")]
        [HttpGet]
        public Book GetBook(int id)
        {
            return _bookService.GetBook(id);
        }

        [Route("Edit")]
        [HttpPost("{id}")]
        public void UpdateBook(int id, Book book)
        {
            if (book.BookId != id)
            {
                Book actualBook = _bookService.GetBook(id);
                _bookService.Update(actualBook);
            }

            _bookService.Update(book);
        }

        [Route("Create")]
        [HttpPost]
        public async void AddBook(Book book)
        {
            if (book != null)
            {
                var user = await _userManager.GetUserByEmail(this.User.Identity.Name);
                book.AuthorId = user.Id.ToString();
                book.ReleaseDate = DateTime.Now;
            }
            _bookService.Create(book);
        }

        [Route("Delete")]
        [HttpPost("{id}")]
        public void DeleteBook(int id)
        {
            var book = _bookService.GetBook(id);
            _bookService.Delete(book);
        }

    }
}