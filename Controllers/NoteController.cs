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

        public NoteController ()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Gets note by ID.
        /// </summary>
        /// <param name="id">ID of the note to be sent.</param>
        /// <returns>Note object.</returns>
        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {
            try { 
                Note note = _unitOfWork.Notes.Get(id);
                return new ApiResponse<Note>(note);
            }
            catch (Exception e)
            {
                return new ApiResponse<string>("Server exception has occured performing request.", new ApiError(e));
            }
        }

        /// <summary>
        /// Store new note.
        /// </summary>
        /// <param name="note">Note entity.</param>
        /// <returns>Note object which was added.</returns>
        [HttpPost]
        public ApiResponse Add([FromBody] Note note)
        {
            try
            {
                
                _unitOfWork.Notes.Create(note);
            }
            catch (Exception e)
            {
                return new ApiResponse<Note>(null, new ApiError(e));
            }

            return new ApiResponse<Note>(note);
        }

        /// <summary>
        /// Updates existing note.
        /// </summary>
        /// <param name="note">Note entity.</param>
        /// <returns>Note object to be updated, id is required.</returns>
        [HttpPut]
        public ApiResponse Update([FromBody] Note note)
        {
            try
            {
                _unitOfWork.Notes.Update(note);
                return new ApiResponse<Note>(note);
            }
            catch (Exception e)
            {
                return new ApiResponse<Note>(null, new ApiError(e));
            }
        }

        /// <summary>
        /// Deletes note by ID
        /// </summary>
        /// <param name="id">ID of the note to be deleted.</param>
        /// <returns>String message.</returns>
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            try
            {
                _unitOfWork.Notes.Delete(id);
                return new ApiResponse<string>("Note[" + id + "] was deleted.");
            }
            catch (Exception e)
            {
                return new ApiResponse<string>(null, new ApiError(e));
            }
        }
    }
}