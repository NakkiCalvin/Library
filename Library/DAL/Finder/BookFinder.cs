using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Entities;
using BLL.Finders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Finder
{
    class BookFinder : Finder<Book>, IBookFinder
    {
        public BookFinder(DbSet<Book> entity) : base(entity)
        {
        }

        public Book GetById(int id)
        {
            return AsQueryable().FirstOrDefault(x => x.BookId == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return AsQueryable().ToList();
        }

        public bool IsBookExists(Book book)
        {
            if (book == null) return false;
            return AsQueryable().Any(x => x.BookId == book.BookId);
        }
    }
}
