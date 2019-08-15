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
        private NoteDbContext db = new NoteDbContext();
        private UserRepository _userRepository;
        private NoteRepository _noteRepository;

        public UserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(db);
                return _userRepository;
            }
        }

        public NoteRepository Notes
        {
            get
            {
                if (_noteRepository == null)
                    _noteRepository = new NoteRepository(db);
                return _noteRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
