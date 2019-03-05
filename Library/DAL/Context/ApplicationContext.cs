using System;
using System.Collections.Generic;
using System.Text;
using BLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Storage> Storage { get; set; }

    }
}
