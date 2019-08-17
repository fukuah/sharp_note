using SharpNote.AppDbContext;
using SharpNote.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.UOW
{
    public class UnitOfWork
    {
        private UserRepository _userRepository;
        private NoteRepository _noteRepository;

        public UserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository();
                return _userRepository;
            }
        }

        public NoteRepository Notes
        {
            get
            {
                if (_noteRepository == null)
                    _noteRepository = new NoteRepository();
                return _noteRepository;
            }
        }
    }
}
