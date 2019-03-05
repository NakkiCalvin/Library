using System;
using System.Linq;
using BLL;
using BLL.Entities;
using BLL.Services;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Add_writes_to_database()
        {
            //var options = new DbContextOptionsBuilder<ApplicationContext>()
            //    .UseInMemoryDatabase(databaseName: "esw376")
            //    .Options;

            // Run the test against one instance of the context
            //var context = new ApplicationContext(options);
            //var service = new MyService(context);
            //service.Add("http://sample.com");
        }

        [Fact]
        public void CheckDataBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "BookAppDb")
                .Options;

            var context = new ApplicationContext(options);
            //    context.Books.Add(new Book() {});
            //    context.Books.Add(new Book() {});
            //    context.Books.Add(new Book() {});
            //    context.SaveChanges();

            //var service = new MyService(context);
            //var result = service.Find("cat");
            //Assert.AreEqual(2, result.Count());

            Assert.NotNull(context);
        }
    }
}
