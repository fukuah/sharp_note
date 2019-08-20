﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Models
{
    public static class ModelMapper
    {
        public static Note ToModel(this Kernel.NoteKernel note)
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

        public static UserInfo ToModel(this Kernel.UserInfoKernel user)
        {
            if (user == null)
                return null;

            var userInfo =  new UserInfo
            {
                Username = user.Username,
                Notes = user.Notes.Select(x => x.ToModel()).ToList()
            };

            foreach (var note in user.Notes)
            {
                userInfo.Notes.Add(ToModel(note));
            }

            return userInfo;
        }

        public static Kernel.NoteKernel ToKernel(this Note note)
        {
            if (note == null)
                return null;

            return new Kernel.NoteKernel
            {
                Header = note.Header ?? null,
                Link = note.Link ?? null,
                Content = note.Content ?? null,
                CreatedAt = note.CreatedAt ?? null,
                AppearAt = note.AppearAt ?? null,
                ExpireAt = note.ExpireAt ?? null
            };
        }


        public static Kernel.UserInfoKernel ToKernel(this UserInfo user)
        {
            if (user == null)
                return null;

            var userInfo = new Kernel.UserInfoKernel
            {
                Username = user.Username,
                Notes = user.Notes.Select(x => x.ToKernel()).ToList()
            };

            return userInfo;
        }
    }
}