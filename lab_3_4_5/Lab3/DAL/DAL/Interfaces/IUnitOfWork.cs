using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGuestRepository Guests { get; }
        IRepository<Post> Posts { get; }
        void Save();
    }
}
