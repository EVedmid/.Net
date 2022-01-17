using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PostRepository : IRepository<Post>
    {
        private readonly NewsContext _context;

        public PostRepository(NewsContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> FindAll()
        {
            return _context.Posts;
        }

        public Post FindById(int id)
        {
            return _context.Posts.Find(id);
        }

        public IEnumerable<Post> FindByPredicate(Func<Post, bool> predicate)
        {
            return _context.Posts.Where(predicate).ToList();
        }

        public void Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
        }

        public void RemoveById(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }
    }
}
