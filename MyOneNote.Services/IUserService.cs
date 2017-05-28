using System.Threading.Tasks;
using MyOneNote.Data;
using MyOneNote.Data.Entity;
using MyOneNote.ViewModels;

namespace MyOneNote.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> Register(UserRegisterVM model);
        UserProfile GetUserProfile(ApplicationUser user);
        Task<bool> Login(LoginVM login);
    }
}