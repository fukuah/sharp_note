using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Services
{
    public interface INoteService
    {
        ViewModels.Note GetOne(int noteID);

        void Delete(int noteID);

        void Create(ViewModels.Note note);

        void Update(ViewModels.Note note);
    }
}
