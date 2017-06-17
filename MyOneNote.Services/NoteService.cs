using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyOneNote.Data.Entity;
using MyOneNote.EF;

namespace MyOneNote.Services
{
    public class NoteService:BaseService<Note>, INoteService
    {

        public NoteService(IUnitOfWork unitOfWork):base(unitOfWork)
        {         
        }

        public override IEnumerable<Note> GetAll()
        {
            var context = _baseRepository.GetContext();
            var notes = context.Set<Note>().Include(note =>note.Category)
                .Include(note=>note.Project);

            return notes.ToList();
        }
    }
}