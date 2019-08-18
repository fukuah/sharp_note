﻿using SharpNote.AppDbContext.Entities;
using SharpNote.ViewModels;
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

        public ViewModels.Note GetOne(int noteID)
        {
            var note = _uniteOfWork.Notes.Get(noteID);
            return GetNoteIfAvailable(note);
        }

        public void Delete(int noteID)
        {
            _uniteOfWork.Notes.Delete(noteID);
        }

        public void Create(ViewModels.Note note)
        {
            var contextNote = NoteDbContextMapper.MapViewModelToContextNote(note);
            _uniteOfWork.Notes.Create(contextNote);

        }

        public void Update(ViewModels.Note note)
        {
            var contextNote = NoteDbContextMapper.MapViewModelToContextNote(note);
            _uniteOfWork.Notes.Update(contextNote);
        }

        public IEnumerable<ViewModels.Note> GetSelection(int offset, int size)
        {
            var notes = _uniteOfWork.Notes.GetSelection(offset, size);
            var noteModels = new List<ViewModels.Note>();
            foreach (var note in notes)
            {
                noteModels.Add(ViewModelMapper.MapContextNote(note));
            }

            return noteModels;
        }

        private ViewModels.Note GetNoteIfAvailable(AppDbContext.Entities.Note note)
        {
            if (note?.AppearAt.HasValue ?? false)
            {
                if (DateTime.Compare(DateTime.Now, note.AppearAt.GetValueOrDefault()) > 0)
                {
                    if (note?.ExpireAt.HasValue ?? false)
                    {
                        if (DateTime.Compare(note.ExpireAt.GetValueOrDefault(), DateTime.Now) > 0)
                        {
                            return ViewModelMapper.MapContextNote(note);
                        }
                    }
                    else
                    {
                        return ViewModelMapper.MapContextNote(note);
                    }
                }
            }
            else if (note?.ExpireAt.HasValue ?? false)
            {
                if (DateTime.Compare(note.ExpireAt.GetValueOrDefault(), DateTime.Now) > 0)
                {
                    return ViewModelMapper.MapContextNote(note);
                }
            } 
            else
            {
                return ViewModelMapper.MapContextNote(note);
            }

            return null;
        }
    }
}
