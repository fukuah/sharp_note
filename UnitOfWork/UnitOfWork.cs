using SharpNote.AppDbContext;
using SharpNote.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.UOW
{
    public class UnitOfWork : IDisposable
    {
        private readonly NoteDbContext _context;
        public UnitOfWork()
        {
            _context = new NoteDbContext();
            Users = new UserRepository(_context);
            Notes = new NoteRepository(_context);
        }

        public UserRepository Users { get; private set; }

        public NoteRepository Notes { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
