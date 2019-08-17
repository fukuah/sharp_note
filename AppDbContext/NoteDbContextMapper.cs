using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpNote.AppDbContext.Entities;


namespace SharpNote.AppDbContext
{
    public static class NoteDbContextMapper
    {
        public static Note MapViewModelToContextNote(ViewModels.Note note)
        {
            if (note == null)
                return null;

            return new Note
            {
                Header = note.Header ?? null,
                Link = note.Link ?? null,
                Content = note.Content ?? null,
                CreatedAt = note.CreatedAt ?? null,
                UpdatedAt = note.UpdatedAt ?? null,
                AppearAt = note.AppearAt ?? null,
                ExpireAt = note.ExpireAt ?? null
            };
        }
    }
}
