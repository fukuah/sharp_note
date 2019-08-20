using SharpNote.AppDbContext.Entities;
using SharpNote.Models;
using SharpNote.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpNote.AppDbContext;

namespace SharpNote.Services
{

    public class NoteService : INoteService
    {
        private UnitOfWork _uniteOfWork;

        public NoteService()
        {
            _uniteOfWork = new UnitOfWork();
        }

        public Kernel.NoteKernel Get(int noteID)
        {
            var note = _uniteOfWork.Notes.Get(noteID);
            return GetNoteIfAvailable(note);
        }

        public void Delete(int noteID)
        {
            _uniteOfWork.Notes.Delete(noteID);
        }

        public void Create(Kernel.NoteKernel note)
        {
            var contextNote = note.ToEntity();
            _uniteOfWork.Notes.Create(contextNote);
        }

        public void Update(Kernel.NoteKernel note)
        {
            var contextNote = note.ToEntity();
            _uniteOfWork.Notes.Update(contextNote);
        }

        public List<Kernel.NoteKernel> GetPage(int number, int size)
        {
            var notes = _uniteOfWork.Notes.GetSelection(size * (number - 1), size);

            return notes.Select(x => x.ToKernel()).ToList();
        }

        public int Count()
        {
            return _uniteOfWork.Notes.Count();
        }

        private Kernel.NoteKernel GetNoteIfAvailable(AppDbContext.Entities.Note note)
        {
            if (note?.AppearAt.HasValue ?? false)
            {
                if (DateTime.Compare(DateTime.Now, note.AppearAt.GetValueOrDefault()) > 0)
                {
                    if (note?.ExpireAt.HasValue ?? false)
                    {
                        if (DateTime.Compare(note.ExpireAt.GetValueOrDefault(), DateTime.Now) > 0)
                        {
                            return note.ToKernel();
                        }
                    }
                    else
                    {
                        return note.ToKernel();
                    }
                }
            }
            else if (note?.ExpireAt.HasValue ?? false)
            {
                if (DateTime.Compare(note.ExpireAt.GetValueOrDefault(), DateTime.Now) > 0)
                {
                    return note.ToKernel();
                }
            } 
            else
            {
                return note.ToKernel();
            }

            return null;
        }
    }
}
