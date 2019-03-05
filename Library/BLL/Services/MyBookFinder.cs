using System;
using System.Collections.Generic;
using System.Text;
using BLL.DataAccess;
using BLL.Entities;

namespace BLL.Services
{
    public class MyBookFinder
    {
        private readonly IFinder<Book, int> _finder;

        public MyBookFinder(IFinder<Book, int> finder)
        {
            _finder = finder;
        }

        public Book FindBook(int id)
        {
            Book actualBook = _finder.Find(id);
            return actualBook;
        }
    }
}
