using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Finder<T, U> : IFinder<T, U> where T : class
    {
        private readonly DbSet<T> _entity;

        public Finder(DbSet<T> entity)
        {
            _entity = entity;
        }

        public T Find(U key)
        {
            return _entity.Find(key);
        }

        public void GetAll()
        {
            _entity.ToList();
        }
    }
}
