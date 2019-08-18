using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpNote.ApiResponseHelpers;
using SharpNote.ViewModels;
using SharpNote.Services;
using SharpNote.UOW;

namespace SharpNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController (INoteService service)
        {
            _noteService = service;
        }

        /// <summary>
        /// Gets note by ID.
        /// </summary>
        /// <param name="id">ID of the note to be sent.</param>
        /// <returns>Note object.</returns>
        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {
            
            Note note = _noteService.GetOne(id);
            return new ApiResponse<Note>(note);
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

                _noteService.Create(note);
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
                _noteService.Update(note);
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
                _noteService.Delete(id);
                return new ApiResponse<string>("Note[" + id + "] was deleted.");
            }
            catch (Exception e)
            {
                return new ApiResponse<string>(null, new ApiError(e));
            }
        }

        /// <summary>
        /// Gets notes using offset and size given.
        /// </summary>
        /// <param name="offset">Offset for note request.</param>
        /// <param name="size">Size for note request.</param>
        /// <returns>Array of Note objects.</returns>
        [HttpGet("{offset}/{size}")]
        public ApiResponse GetBunch(int offset, int size)
        {
            try
            {
                var notes = _noteService.GetSelection(offset, size);
                return new ApiResponse<Note []>(notes.ToArray());
            }
            catch (Exception e)
            {
                return new ApiResponse<Note []>(new Note [0], new ApiError(e));
            }
        }
    }
}