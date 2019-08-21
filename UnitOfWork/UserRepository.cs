using System;
using System.Linq;
using System.Collections.Generic;
using SharpNote.AppDbContext.Entities;
using SharpNote.AppDbContext;
using Microsoft.EntityFrameworkCore;


namespace SharpNote.UOW
{
    public class UserRepository : IRepository<User>
    {
        private readonly NoteDbContext _context;
        public UserRepository(NoteDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            users.AddRange(_context.Users.Include(o => o.Notes));
            return users;
        }

        public User Get(int id)
        {

            return _context.Users.Find(id);


        }

        public User Get(string username)
        {

            return _context.Users.Where(u => u.Username == username).FirstOrDefault<User>();

        }

        public void Create(User user)
        {

            user.CreatedAt = DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();

        }

        public void Update(User user)
        {

            user.UpdatedAt = DateTime.Now;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

            User user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

        }
    }
}
