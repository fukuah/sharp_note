using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpNote.AppDbContext.Entities;


namespace SharpNote.AppDbContext
{
    public static class NoteDbContextMapper
    {
        public static Note ToEntity(this Kernel.NoteKernel note)
        {
            if (note == null)
                return null;

            return new Note
            {
                Header = note.Header ,
                Link = note.Link ,
                Content = note.Content ,
                AppearAt = note.AppearAt ,
                ExpireAt = note.ExpireAt ,
            };
        }

        public static Kernel.UserInfoKernel ToKernel(this User user)
        {
            if (user == null)
                return null;

            return new Kernel.UserInfoKernel
            {
                Username = user.Username,
                Friends = user.Friends?.Select(x => x.ToKernel().ToUserKernel()).ToList(),
                Notes = user.Notes?.Select(x => x.ToKernel()).ToList(),
                CreatedAt = user.CreatedAt
            };
        }

        public static Kernel.NoteKernel ToKernel(this Note note)
        {
            if (note == null)
                return null;

            return new Kernel.NoteKernel
            {
                Header = note.Header ,
                Link = note.Link ,
                Content = note.Content ,
                AppearAt = note.AppearAt ,
                ExpireAt = note.ExpireAt ,
                //Permissions = note.Permissions.Select(x => x.ToKernel().ToUserKernel()).ToList()
            };
        }
    }
}
