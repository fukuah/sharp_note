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

        public Models.Note Get(int noteID)
        {
            var note = _uniteOfWork.Notes.Get(noteID);
            return GetNoteIfAvailable(note);
        }

        public void Delete(int noteID)
        {
            _uniteOfWork.Notes.Delete(noteID);
        }

        public void Create(Models.Note note)
        {
            var contextNote = note.ToEntity();
            _uniteOfWork.Notes.Create(contextNote);

        }

        public void Update(Models.Note note)
        {
            var contextNote = note.ToEntity();
            _uniteOfWork.Notes.Update(contextNote);
        }

        public Pagination<Models.Note> GetPage(int pageNumber)
        {
            int noteCount = _uniteOfWork.Notes.Count();
            var page = new Pagination<Models.Note>(pageNumber, noteCount);

            var notes = _uniteOfWork.Notes.GetSelection(page.Size * (page.Number - 1), page.Size);
            if (notes.Count() > 0)
                page.Content.AddRange(notes.ToModelList());

            return page;
        }

        private Models.Note GetNoteIfAvailable(AppDbContext.Entities.Note note)
        {
            if (note?.AppearAt.HasValue ?? false)
            {
                if (DateTime.Compare(DateTime.Now, note.AppearAt.GetValueOrDefault()) > 0)
                {
                    if (note?.ExpireAt.HasValue ?? false)
                    {
                        if (DateTime.Compare(note.ExpireAt.GetValueOrDefault(), DateTime.Now) > 0)
                        {
                            return note.ToModel();
                        }
                    }
                    else
                    {
                        return note.ToModel();
                    }
                }
            }
            else if (note?.ExpireAt.HasValue ?? false)
            {
                if (DateTime.Compare(note.ExpireAt.GetValueOrDefault(), DateTime.Now) > 0)
                {
                    return note.ToModel();
                }
            } 
            else
            {
                return note.ToModel();
            }

            return null;
        }
    }
}
