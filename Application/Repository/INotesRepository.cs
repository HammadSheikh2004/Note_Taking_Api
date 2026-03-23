using Domain.DTOs;
using Domain.Note_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface INotesRepository
    {
        public Task<Note> CreateNoteAsync(NotesDTOs notesDTOs);
        public Task<List<Note>> GetNoteAsync();
        public Task<List<Note>> GetNoteByIdAsync(int id);
        public Task<NotesDTOs> UpdateNoteAsync(NotesDTOs noteDto, int id);
        public Task<bool> DeleteNoteAsync(int id);

    }
}
