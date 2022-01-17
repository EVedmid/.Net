using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly NewsContext _context;

        public GuestRepository(NewsContext context)
        {
            _context = context;
        }

        public IEnumerable<Guest> FindAll()
        {
            return _context.Guests;
        }

        public Guest FindById(int id)
        {
            return _context.Guests.Find(id);
        }

        public IEnumerable<Guest> FindByPredicate(Func<Guest, bool> predicate)
        {
            return _context.Guests.Where(predicate).ToList();
        }

        public void Create(Guest guest)
        {
            _context.Guests.Add(guest);
            _context.SaveChanges();
        }

        public void Update(Guest guest)
        {
            _context.Entry(guest).State = EntityState.Modified;
        }

        public void RemoveByLogin(string login)
        {
            var user = _context.Guests.Find(login);
            if (user != null)
            {
                _context.Guests.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
        public Guest FindByLogin(string login)
        {
            return _context.Guests.Find(login);
        }

        public void RemoveById(int id) {}
    }
}
