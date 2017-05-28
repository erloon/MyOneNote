using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyOneNote.Data;
using MyOneNote.Data.Entity;
using MyOneNote.EF;
using MyOneNote.Services;

namespace MyOneNote.API.Infrastructure
{
    public class BaseController :Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IUserService _userService;
        public UserProfile UserProfile { get; private set; }

        public BaseController(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            _userService = userService;
            _userManager = userManager;
            GetProfile();
        }

        private UserProfile GetProfile()
        {
            var applicationUser =  _userManager.GetUserAsync(this.User).Result;
            return UserProfile = _userService.GetUserProfile(applicationUser);
        }
    }
}