using Application.Services;
using Domain.DTOs;
using Domain.Note_Entity;
using Infrastructure.NoteRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Note_Taking_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly NoteServices _noteService;

        public NoteController(NoteServices noteService)
        {
            _noteService = noteService;
        }

        [HttpPost("CreateNotes")]
        public async Task<IActionResult> CreateNote(NotesDTOs notesDTOs)
        {
            var data = await _noteService.CreateNoteAsync(notesDTOs);
            return Ok(new { data, successMessage = "Note Add Successfully!" });
        }
        [HttpGet("GetNotes")]
        public async Task<IActionResult> GetNotes()
        {
            var data = await _noteService.GetNoteAsync();
            if (data.Count == 0)
            {
                return NotFound(new { errorMessage = "No Notes Found!" });
            }
            return Ok(data);
        }
        [HttpGet("GetNoteById/{id}")]
        public async Task<IActionResult> GetNoteById(int id)
        {
            var data = await _noteService.GetNoteByIdAsync(id);
            if (data.Count == 0)
            {
                return NotFound(new { errorMessage = "No Note Found!" });
            }
            return Ok(data);
        }

        [HttpPut("UpdateNote/{id}")]
        public async Task<IActionResult> UpdateNote(NotesDTOs notesDTOs, int id)
        {
            var data = await _noteService.UpdateNoteAsync(notesDTOs, id);
            if (data == null)
            {
                return NotFound(new { errorMessage = "No Note Found!" });
            }
            return Ok(new { data, successMessage = "Note Updated Successfully!" });
        }
        [HttpDelete("DeleteNote/{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var isDeleted = await _noteService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound(new { errorMessage = "No Note Found!" });
            }
            return Ok(new { successMessage = "Note Deleted Successfully!" });
        }
    }
}
