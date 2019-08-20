using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Models
{
    public static class ModelMapper
    {
        public static Note ToModel(this SharpNote.AppDbContext.Entities.Note note)
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

        public static IEnumerable<Note> ToModelList(this IEnumerable<SharpNote.AppDbContext.Entities.Note> notes)
        {
            if (notes == null)
                return new List<Note>();

            var noteModels = new List<Note>();
            foreach (var note in notes)
            {
                noteModels.Add(new Note
                    {
                        Username = note.Creator?.Username,
                        Header = note.Header ?? null,
                        Link = note.Link ?? null,
                        Content = note.Content ?? null,
                        CreatedAt = note.CreatedAt ?? null,
                        AppearAt = note.AppearAt ?? null,
                        ExpireAt = note.ExpireAt ?? null
                    }
                );
            }

            return noteModels;
        }

        public static UserInfo ToModel(this SharpNote.AppDbContext.Entities.User user)
        {
            if (user == null)
                return null;

            var userInfo =  new UserInfo
            {
                Username = user.Username,
                CreatedAt = user.CreatedAt,
            };

            foreach (var note in user.Notes)
            {
                userInfo.Notes.Add(ToModel(note));
            }

            return userInfo;
        }
    }
}
