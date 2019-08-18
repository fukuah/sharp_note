using System;
using System.Linq;
using System.Collections.Generic;
using SharpNote.AppDbContext.Entities;
using SharpNote.AppDbContext;
using Microsoft.EntityFrameworkCore;


namespace SharpNote.UOW
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public class NoteRepository : IRepository<Note>
    {

        public IEnumerable<Note> GetAll()
        {
            var notes = new List<Note>();
            using (var db = new NoteDbContext())
            {
                notes.AddRange(db.Notes);
            }

            return notes;
        }

        public Note Get(int id)
        {
            using (var db = new NoteDbContext())
            {
                return db.Notes.Find(id);
            }
        }

        public void Create(Note note)
        {
            using (var db = new NoteDbContext())
            {
                db.Notes.Add(note);
                db.SaveChanges();
            }
        }

        public void Update(Note note)
        {
            using (var db = new NoteDbContext())
            {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new NoteDbContext())
            {
                Note note = db.Notes.Find(id);
                if (note != null)
                {
                    db.Notes.Remove(note);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Note> GetSelection(int offset, int size)
        {
            var notes = new List<Note>();
            using (var db = new NoteDbContext())
            {
                notes.AddRange(db.Notes.OrderBy(p => p.CreatedAt).Skip(offset).Take(size).ToList());
            }

            return notes;
        }
    }

    public class UserRepository : IRepository<User>
    {
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

        public void Create(User user)
        {
            using (var db = new NoteDbContext())
            {
                db.Users.Add(user);
            }
        }

        public void Update(User user)
        {
            using (var db = new NoteDbContext())
            {
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
