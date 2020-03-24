using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_EF.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
