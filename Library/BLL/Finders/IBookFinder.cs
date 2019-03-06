using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Finders
{
    public interface IBookFinder
    {
        Book GetById(int id);
        IEnumerable<Book> GetAll();
        bool IsBookExists(Book book);
    }
}
