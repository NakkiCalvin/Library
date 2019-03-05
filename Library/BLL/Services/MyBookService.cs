using System.Collections.Generic;
using BLL.DataAccess;
using BLL.Entities;

namespace BLL.Services
{
    public class MyBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Book> _repository;

        public MyBookService(IUnitOfWork unitOfWork, IRepository<Book> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Create(Book book)
        {
            _repository.Create(book);
            _unitOfWork.Commit();
        }

        public void Update(Book book)
        {
            _repository.Update(book);
            _unitOfWork.Commit();
        }

        public void Delete(Book book)
        {
            _repository.Delete(book);
            _unitOfWork.Commit();
        }

        public void Create(IEnumerable<Book> books)
        {
            _repository.Create(books);
            _unitOfWork.Commit();
        }

        public void Update(IEnumerable<Book> books)
        {
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
