using System.Collections.Generic;
using BLL.DataAccess;
using BLL.Entities;

namespace BLL.Services
{
    public class MyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Book> _repository;

        public MyService(IUnitOfWork unitOfWork, IRepository<Book> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Add(string name)
        {
            var book = new Book() { Name = name};
            _repository.Create(book);
            _unitOfWork.Commit();
        }

        public void Find(int id)
        {

        }
    }
}
