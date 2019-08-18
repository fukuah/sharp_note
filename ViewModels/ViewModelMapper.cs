using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.ViewModels
{
    public static class ViewModelMapper
    {
        public static Note MapContextNote(SharpNote.AppDbContext.Entities.Note note)
        {
            if (note == null)
                return null;

            return new Note
            {
                Username = note.Creator?.Username,
                Header = note.Header ?? null,
                Link = note.Link ?? null,
                Content = note.Content ?? null,
                CreatedAt = note.CreatedAt ?? null,
                AppearAt = note.AppearAt ?? null,
                ExpireAt = note.ExpireAt ?? null
            };
        }
    }
}
