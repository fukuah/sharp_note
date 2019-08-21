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

            notes.AddRange(_context.Notes);
            return notes;
        }

        public Note Get(int id)
        {
            return _context.Notes.Find(id);
        }

        public void Create(Note note)
        {
            note.CreatedAt = DateTime.Now;
            _context.Notes.Add(note);
        }

        public void Update(Note note)
        {
            note.UpdatedAt = DateTime.Now;
            _context.Entry(note).State = EntityState.Modified;
        }

        internal int Count()
        {
            int count = _context.Notes.Count();


            return count;
        }

        public void Delete(int id)
        {
            Note note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
            }

        }

        public IEnumerable<Note> GetSelection(int offset, int size)
        {
            var notes = new List<Note>();

            notes.AddRange(_context.Notes.OrderBy(p => p.CreatedAt).Skip(offset).Take(size).ToList());

            return notes;

        }
    }
}
