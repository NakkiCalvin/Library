using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Finder<T> : IFinder<T> where T : class
    {
        private readonly DbSet<T> _entity;

        public Finder(DbSet<T> entity)
        {
            _entity = entity;
        }

        public void Find(T key)
        {
            _entity.Find(key);
        }

        public void GetAll()
        {
            _entity.ToList();
        }
    }
}
