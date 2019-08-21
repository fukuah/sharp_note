using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpNote.ApiResponseHelpers;
using SharpNote.Models;
using SharpNote.Services;
using SharpNote.UOW;

namespace SharpNote.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService service)
        {
            _noteService = service;
        }

        /// <summary>
        /// Gets note by ID.
        /// </summary>
        /// <param name="id">ID of the note to be sent.</param>
        /// <returns>Note object.</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ApiResponse Get(int id)
        {
            NoteModel note = _noteService.Get(id).ToModel();
            return new ApiResponse<NoteModel>(note);
        }

        /// <summary>
        /// Store new note.
        /// </summary>
        /// <param name="note">Note entity.</param>
        /// <returns>Note object which was added.</returns>
        [HttpPost]
        public ApiResponse Add([FromBody] NoteModel note)
        {
            _noteService.Create(note.ToKernel());
            return new ApiResponse<NoteModel>(note);
        }

        /// <summary>
        /// Updates existing note.
        /// </summary>
        /// <param name="note">Note entity.</param>
        /// <returns>Note object to be updated, id is required.</returns>
        [HttpPut]
        public ApiResponse Update([FromBody] NoteModel note)
        {
            _noteService.Update(note.ToKernel());
            return new ApiResponse<NoteModel>(note);
        }

        /// <summary>
        /// Deletes note by ID
        /// </summary>
        /// <param name="id">ID of the note to be deleted.</param>
        /// <returns>String message.</returns>
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            _noteService.Delete(id);
            return new ApiResponse<string>("Note[" + id + "] was deleted.");
        }

        /// <summary>
        /// Gets page of notes.
        /// </summary>
        /// <param name="number">Page number.</param>
        /// <returns>Array of Note objects.</returns>
        [HttpGet("page/{number}")]
        public ApiResponse GetPage(int number)
        {
            int count = _noteService.Count();
            var page = new PaginationModel<NoteModel>(number, count);
            var notes = _noteService.GetPage(number, page.Size);
            page.Content = notes.Select(x => x.ToModel()).ToList();

            return new ApiResponse<PaginationModel<NoteModel>>(page);

        }
    }
}