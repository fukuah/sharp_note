using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Models
{
    public static class ModelMapper
    {
        public static NoteModel ToModel(this Kernel.NoteKernel note)
        {
            if (note == null)
                return null;

            return new NoteModel
            {
                Username = note.Creator?.Username,
                Header = note.Header,
                Link = note.Link,
                Content = note.Content,
                CreatedAt = note.CreatedAt,
                AppearAt = note.AppearAt,
                ExpireAt = note.ExpireAt
            };
        }

        public static UserInfoModel ToModel(this Kernel.UserInfoKernel user)
        {
            if (user == null)
                return null;

            var userInfo = new UserInfoModel
            {
                Username = user.Username,
                Notes = user.Notes?.Select(x => x.ToModel()).ToList()
            };

            return userInfo;
        }

        public static Kernel.NoteKernel ToKernel(this NoteModel note)
        {
            if (note == null)
                return null;

            return new Kernel.NoteKernel
            {
                Header = note.Header,
                Link = note.Link,
                Content = note.Content,
                CreatedAt = note.CreatedAt,
                AppearAt = note.AppearAt,
                ExpireAt = note.ExpireAt
            };
        }


        public static Kernel.UserInfoKernel ToKernel(this UserInfoModel user)
        {
            if (user == null)
                return null;

            var userInfo = new Kernel.UserInfoKernel
            {
                Username = user.Username,
                Notes = user.Notes?.Select(x => x.ToKernel()).ToList()
            };

            return userInfo;
        }
    }
}
