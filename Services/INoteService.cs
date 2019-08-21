using SharpNote.Kernel;
using SharpNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Services
{
    public interface INoteService
    {
        NoteKernel Get(int noteID);

        void Delete(int noteID);

        void Create(NoteKernel note);

        void Update(NoteKernel note);

        List<NoteKernel> GetPage(int number, int size);

        int Count();
    }
}
