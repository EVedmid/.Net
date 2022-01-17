using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        IEnumerable<T> FindByPredicate(Func<T, bool> predicate);
        void Create(T item);
        void Update(T item);
        void RemoveById(int id);
    }
}
