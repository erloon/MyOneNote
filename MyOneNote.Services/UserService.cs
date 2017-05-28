using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyOneNote.Data;
using MyOneNote.Data.Entity;
using MyOneNote.EF;
using MyOneNote.Infrastructure.Exceptions;
using MyOneNote.ViewModels;

namespace MyOneNote.Services
{
    public class UserService:BaseService<UserProfile>, IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _loginManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public UserService(
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> loginMenager,
            RoleManager<IdentityRole> roleManager):base(unitOfWork)
        {
            _userManager = userManager;
            _loginManager = loginMenager;
            _roleManager = roleManager;
        }

        public async Task<ApplicationUser> Register(UserRegisterVM model)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.FullName = model.FullName;
            user.BirthDate = model.BirthDate;

            IdentityResult result = await _userManager.CreateAsync
                (user, model.Password);
            if (!result.Succeeded)
                throw new RegisterUserException(result.Errors.ToString());


            if (!_roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "NormalUser";
              
                IdentityResult roleResult = _roleManager.
                    CreateAsync(role).Result;
                if (!roleResult.Succeeded)
                {
                    throw new RegisterUserException(roleResult.Errors.ToString());
                }
            }

            _userManager.AddToRoleAsync(user,
                "NormalUser").Wait();


            PerformCommand(() =>
            {
                _baseRepository.Insert(new UserProfile()
                {
                    UserId = user.Id,
                });
            });
            

            return user;
        }

        public UserProfile GetUserProfile(ApplicationUser user)
        {
            return _baseRepository.Find(new UserProfile() {UserId = user.Id});
        }

        public async Task<bool> Login(LoginVM login)
        {
            var result = await _loginManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
                return true;
            return false;

        }
    }
}