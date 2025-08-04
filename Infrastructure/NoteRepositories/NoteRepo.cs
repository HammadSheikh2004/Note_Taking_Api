using Application.Repository;
using Domain.DTOs;
using Domain.Note_Entity;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.NoteRepositories
{
    public class NoteRepo : INotesRepository
    {
        private readonly MyDbContext _context;
        public NoteRepo(MyDbContext context)
        {
            this._context = context;
        }
        public async Task<Note> CreateNoteAsync(NotesDTOs notesDTOs)
        {
            var note = new Note
            {
                Title = notesDTOs.Title,
                Content = notesDTOs.Content,
                CreatedAt = DateTime.Now,
            };
            _context.notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }
        public Task<List<Note>> GetNoteAsync()
        {
            return Task.FromResult(_context.notes.ToList());
        }

        public Task<List<Note>> GetNoteByIdAsync(int id)
        {
            return Task.FromResult(_context.notes.Where(n => n.NoteId == id).ToList());
        }

        public async Task<NotesDTOs> UpdateNoteAsync(NotesDTOs note, int id)
        {
            var existingNote = await _context.notes.FirstOrDefaultAsync(n => n.NoteId == id);
            if (existingNote == null)
            {
                throw new KeyNotFoundException($"Note with ID {id} not found.");
            }

            existingNote.Title = note.Title;
            existingNote.Content = note.Content;

            await _context.SaveChangesAsync();

            return new NotesDTOs
            {
                Title = existingNote.Title,
                Content = existingNote.Content
            };
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            var data = await _context.notes.FirstOrDefaultAsync(x => x.NoteId == id);
            if (data == null)
            {
                return false;
            }
            _context.notes.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
