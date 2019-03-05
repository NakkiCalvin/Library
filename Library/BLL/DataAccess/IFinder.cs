using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataAccess
{
    public interface IFinder<T> where T : class
    {
        void Find(T entity);
        void GetAll();
    }
}
