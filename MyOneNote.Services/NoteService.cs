using System.ComponentModel.DataAnnotations;
using MyOneNote.Data.Entity;
using MyOneNote.EF;

namespace MyOneNote.Services
{
    public class NoteService:BaseService<Note>, INoteService
    {

        public NoteService(IUnitOfWork unitOfWork):base(unitOfWork)
        {         
        }


        
    }
}