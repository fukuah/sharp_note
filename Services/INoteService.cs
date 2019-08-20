using SharpNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Services
{
    public interface INoteService
    {
        Kernel.NoteKernel Get(int noteID);

        void Delete(int noteID);

        void Create(Kernel.NoteKernel note);

        void Update(Kernel.NoteKernel note);

        List<Kernel.NoteKernel> GetPage(int number, int size);

        int Count();
    }
}
