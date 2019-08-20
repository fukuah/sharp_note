using SharpNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Services
{
    public interface INoteService
    {
        Models.Note Get(int noteID);

        void Delete(int noteID);

        void Create(Models.Note note);

        void Update(Models.Note note);

        Pagination<Models.Note> GetPage(int number);
    }
}
