using MyOneNote.Data.Entity;
using MyOneNote.EF;

namespace MyOneNote.Services
{
    public class ProjectService:BaseService<Project>,IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}