using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataAccess
{
    public interface IFinder<T, U> where T : class
    {
        T Find(U entity);
        void GetAll();
    }
}
