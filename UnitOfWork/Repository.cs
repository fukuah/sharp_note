using System;
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
            using (var db = new NoteDbContext())
            {
                return db.Notes;
            }
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
    }

    public class UserRepository : IRepository<User>
    {
        public IEnumerable<User> GetAll()
        {
            using (var db = new NoteDbContext())
            {
                return db.Users.Include(o => o.Notes);
            }
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
