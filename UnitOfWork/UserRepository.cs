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
            using (var db = new NoteDbContext())
            {
                users.AddRange(db.Users.Include(o => o.Notes));
            }
            return users;
        }

        public User Get(int id)
        {
            using (var db = new NoteDbContext())
            {
                return db.Users.Find(id);
            }

        }

        public User Get(string username)
        {
            using (var db = new NoteDbContext())
            {
                return db.Users.Where(u => u.Username == username).FirstOrDefault<User>();
            }
        }

        public void Create(User user)
        {
            using (var db = new NoteDbContext())
            {
                user.CreatedAt = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using (var db = new NoteDbContext())
            {
                user.UpdatedAt = DateTime.Now;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new NoteDbContext())
            {
                User user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }
    }
}
