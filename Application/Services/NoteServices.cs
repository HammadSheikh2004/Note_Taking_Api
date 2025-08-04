using Application.Repository;
using Domain.DTOs;
using Domain.Note_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NoteServices
    {
        private readonly INotesRepository _notesRepository;
        public NoteServices(INotesRepository notesRepository)
        {
            this._notesRepository = notesRepository;
        }
        public async Task<Note> CreateNoteAsync(NotesDTOs notesDTOs)
        {
            return await _notesRepository.CreateNoteAsync(notesDTOs);
        }
        public async Task<List<Note>> GetNoteAsync()
        {
            return await _notesRepository.GetNoteAsync();
        }
        public async Task<List<Note>> GetNoteByIdAsync(int id)
        {
            return await _notesRepository.GetNoteByIdAsync(id);
        }
        public async Task<NotesDTOs> UpdateNoteAsync(NotesDTOs note, int id)
        {
            return await _notesRepository.UpdateNoteAsync(note, id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
           var deleteId = await _notesRepository.DeleteNoteAsync(id);
            if (deleteId)
            {
                return true;
            }
            else
            {
                throw new KeyNotFoundException($"Note with ID {id} not found.");
            }
        }
    }
}
