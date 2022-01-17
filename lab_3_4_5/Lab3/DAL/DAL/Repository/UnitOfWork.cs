using DAL.Context;
using DAL.Entity;
using System;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewsContext _context;
        private GuestRepository _guestRepository;
        private PostRepository _postRepository;

        public UnitOfWork()
        {
            _context = new NewsContext();
        }

        public IGuestRepository Guests
        {
            get { return _guestRepository ??= new GuestRepository(_context); }
        }

        public IRepository<Post> Posts
        {
            get { return _postRepository ??= new PostRepository(_context); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
