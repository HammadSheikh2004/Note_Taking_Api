using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Note_Entity
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        [Required(ErrorMessage = "Title is Required!")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Content is Required!")]
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
