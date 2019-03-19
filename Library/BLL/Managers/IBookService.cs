using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Managers
{
    public interface IBookService
    {
        Book GetBook(int id);
        IEnumerable<Book> GetAll();
        void Create(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}