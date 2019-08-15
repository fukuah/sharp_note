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
        private NoteDbContext db;

        public NoteRepository(NoteDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Note> GetAll()
        {
            return db.Notes;
        }

        public Note Get(int id)
        {
            return db.Notes.Find(id);
        }

        public void Create(Note note)
        {
            db.Notes.Add(note);
        }

        public void Update(Note note)
        {
            db.Entry(note).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Note note = db.Notes.Find(id);
            if (note != null)
                db.Notes.Remove(note);
        }
    }

    public class UserRepository : IRepository<User>
    {
        private NoteDbContext db;

        public UserRepository(NoteDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.Include(o => o.Notes);
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
