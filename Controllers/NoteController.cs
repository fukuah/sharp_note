using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpNote.ApiResponseHelpers;
using SharpNote.AppDbContext.Entities;
using SharpNote.UOW;

namespace SharpNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private UnitOfWork _unitOfWork;

        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {
            return new ApiResponse<int>(id);
        }

        // GET api/values
        /// <summary>
        /// Store new note
        /// </summary>
        /// <param name="note">Note entity</param>
        /// <returns>Note object which was added</returns>
        [HttpPost]
        public ApiResponse AddNote([FromBody] Note note)
        {
            _unitOfWork = new UnitOfWork();
            _unitOfWork.Notes.Create(note);
            _unitOfWork.Save();

            return new ApiResponse<Note>(note);
        }
    }
}