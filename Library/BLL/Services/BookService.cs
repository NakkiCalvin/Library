using System.Collections.Generic;
using BLL.DataAccess;
using BLL.Entities;
using BLL.Finders;

namespace BLL.Services
{
    public class BookService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IRepository<Book> _repository;
        readonly IBookFinder _finder;

        public BookService(IUnitOfWork unitOfWork, IRepository<Book> repository, IBookFinder finder)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _finder = finder;
        }

        public Book GetBook(int id)
        {
            return _finder.GetById(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _finder.GetAll();
        }

        public void Create(Book book)
        {
            if(book == null) return;
            _repository.Create(book);
            _unitOfWork.Commit();
        }

        public void Update(Book book)
        {
            if (book == null) return;
            _repository.Update(book);
            _unitOfWork.Commit();
        }

        public void Delete(Book book)
        {
            if (book == null) return;
            _repository.Delete(book);
            _unitOfWork.Commit();
        }

        public void Create(IEnumerable<Book> books)
        {
            if (books == null) return;
            _repository.Create(books);
            _unitOfWork.Commit();
        }

        public void Update(IEnumerable<Book> books)
        {
            if (books == null) return;
            _repository.Update(books);
            _unitOfWork.Commit();
        }

        public void Delete(IEnumerable<Book> books)
        {
            _repository.Delete(books);
            _unitOfWork.Commit();
        }

    }
}
