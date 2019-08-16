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

        /// <summary>
        /// Gets note by ID.
        /// </summary>
        /// <param name="id">ID of the note to be sent.</param>
        /// <returns>Note object.</returns>
        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {
            _unitOfWork = new UnitOfWork();
            try { 
                Note note = _unitOfWork.Notes.Get(id);
                _unitOfWork.Dispose();
                return new ApiResponse<Note>(note);
            }
            catch (Exception e)
            {
                _unitOfWork.Dispose();
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
            _unitOfWork = new UnitOfWork();
            try
            {
                
                _unitOfWork.Notes.Create(note);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
            }
            catch (Exception e)
            {
                _unitOfWork.Dispose();
                return new ApiResponse<string>("Server exception has occured performing request.", new ApiError(e));
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
                _unitOfWork = new UnitOfWork();
                _unitOfWork.Notes.Update(note);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return new ApiResponse<Note>(note);
            }
            catch (Exception e)
            {
                _unitOfWork.Dispose();
                return new ApiResponse<string>("Server exception has occured performing request.", new ApiError(e));
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
            _unitOfWork = new UnitOfWork();
            try
            {
                _unitOfWork.Notes.Delete(id);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return new ApiResponse<string>("Note[" + id + "] was deleted.");
            }
            catch (Exception e)
            {
                _unitOfWork.Dispose();
                return new ApiResponse<string>("Server exception has occured performing request.", new ApiError(e));
            }
        }
    }
}