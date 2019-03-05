using System;
using System.Collections.Generic;
using System.Text;
using BLL.DataAccess;
using BLL.Entities;

namespace BLL.Services
{
    public class MyFinder
    {
        private readonly IFinder<Book> _finder;

        public MyFinder(IFinder<Book> finder)
        {
            _finder = finder;
        }

        public void FindBook(int id)
        {
            _finder.Find(id);
        }

    }
}
