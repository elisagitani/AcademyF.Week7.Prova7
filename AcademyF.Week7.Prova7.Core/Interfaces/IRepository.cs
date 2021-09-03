using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week7.Prova7.Core.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Fetch(Func<T, bool> filter = null);
        T Get(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
