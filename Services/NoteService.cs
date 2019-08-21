using SharpNote.AppDbContext.Entities;
using SharpNote.Models;
using SharpNote.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpNote.AppDbContext;
using SharpNote.Kernel;

namespace SharpNote.Services
{

    public class NoteService : INoteService
    {

        public NoteKernel Get(int noteID)
        {
            Note note;
            using (var uow = new UnitOfWork())
            {
                note = uow.Notes.Get(noteID);
            }
            NoteKernel noteKernel = note?.ToKernel();

            return (noteKernel?.IsAvailible() ?? false) ? noteKernel : null;
        }

        public void Delete(int noteID)
        {
            using (var uow = new UnitOfWork())
            {
                uow.Notes.Delete(noteID);
                uow.SaveChanges();
            }
        }

        public void Create(NoteKernel note)
        {
            var contextNote = note.ToEntity();
            using (var uow = new UnitOfWork())
            {
                uow.Notes.Create(contextNote);
                uow.SaveChanges();
            }
        }

        public void Update(NoteKernel note)
        {
            var contextNote = note.ToEntity();
            using (var uow = new UnitOfWork())
            {
                uow.Notes.Update(contextNote);
                uow.SaveChanges();
            }
        }

        public List<NoteKernel> GetPage(int number, int size)
        {
            IEnumerable<Note> notes;
            using (var uow = new UnitOfWork())
            {
                notes = uow.Notes.GetSelection(size * (number - 1), size);
            }
            return notes?.Select(x => x.ToKernel()).ToList();
        }


        public int Count()
        {
            int count;
            using (var uow = new UnitOfWork())
            {
                count = uow.Notes.Count();
            }
            return count;
        }
    }
}
