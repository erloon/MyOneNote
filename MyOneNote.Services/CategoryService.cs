using MyOneNote.Data.Entity;
using MyOneNote.EF;

namespace MyOneNote.Services
{
    public class CategoryService:BaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}