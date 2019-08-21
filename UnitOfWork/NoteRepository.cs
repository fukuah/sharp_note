using System;
using System.Linq;
using System.Collections.Generic;
using SharpNote.AppDbContext.Entities;
using SharpNote.AppDbContext;
using Microsoft.EntityFrameworkCore;


namespace SharpNote.UOW
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly NoteDbContext _context;
        public NoteRepository(NoteDbContext context)
        {
            _context = context;
        }

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
                note.CreatedAt = DateTime.Now;
                db.Notes.Add(note);
                db.SaveChanges();
            }
        }

        public void Update(Note note)
        {
            using (var db = new NoteDbContext())
            {
                note.UpdatedAt = DateTime.Now;
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        internal int Count()
        {
            int count;
            using (var db = new NoteDbContext())
            {
                count = db.Notes.Count();
            }

            return count;
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
}
