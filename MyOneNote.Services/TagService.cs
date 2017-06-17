using MyOneNote.Data.Entity;
using MyOneNote.EF;

namespace MyOneNote.Services
{
    public class TagService :BaseService<Tag>,ITagService
    {
        public TagService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}