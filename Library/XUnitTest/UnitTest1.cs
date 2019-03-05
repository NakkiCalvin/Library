using System;
using System.Linq;
using BLL;
using BLL.DataAccess;
using BLL.Entities;
using BLL.Services;
using DAL;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses.ResultOperators;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {
        public static DbContextOptions<ApplicationContext> options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "BookAppDb")
            .Options;

        public ApplicationContext context = new ApplicationContext(options);

        [Fact]
        public void WriteToBase()
        {
            context.Books.Add(new Book() { BookId = 1, Name = "Jungle", ReleaseDate = new DateTime(2005, 05, 02) });
            context.Books.Add(new Book() { BookId = 2, Name = "Cake", ReleaseDate = new DateTime(2005, 05, 02) });
            context.Books.Add(new Book() { BookId = 3, Name = "Smth", ReleaseDate = new DateTime(2005, 05, 02) });
            context.SaveChanges();
        
            Assert.Equal(3, context.Books.Count());

        }

        [Fact]
        public void CheckDataBase()
        {
            Assert.NotNull(context);
        }

        [Fact]
        public void CheckContains()
        {
            var ufo = new UnitOfWork(context);
            var finder = new Finder<Book, int>(context.Books); 
            var repository = new Repository<Book>(context.Books);

            var service = new MyBookService(ufo, repository);
            var book = new Book { BookId = 1, Name = "Cake", ReleaseDate = new DateTime(2009, 01, 03) };
            service.Create(book);

            var findBookFinder = new MyBookFinder(finder);
            findBookFinder.FindBook(1);

            Assert.NotNull(findBookFinder.FindBook(1));
        }

        [Fact]
        public void CheckRemove()
        {
            var ufo = new UnitOfWork(context);
            var repository = new Repository<Book>(context.Books);
            var finder = new Finder<Book, int>(context.Books);

            var service = new MyBookService(ufo, repository);
            var findBookFinder = new MyBookFinder(finder);

            var book = new Book { BookId = 1, Name = "Cake", ReleaseDate = new DateTime(2009, 01, 03) };
            service.Create(book);
            service.Delete(book);
            
            Assert.Null(context.Books.Where(p => p.Name == "Cake"));
        }
    }
}
