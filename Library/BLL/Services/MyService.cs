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

        public void Add(string url)
        {
            var book = new Book() { Name = "cake"};
            //_repository.Books.Add(blog);
            //_context.SaveChanges();
        }

        /*public IEnumerable<Blog> Find(string term)
        {
            return _context.Books
                .Where(b => b.Name.Contain(term))
                .OrderBy(b => b.Url)
                .ToList();
        }*/
    }
}
