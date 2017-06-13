using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyOneNote.Data;
using MyOneNote.Data.Entity;
using MyOneNote.Services;

namespace MyOneNote.WWW.Infrastructure
{
    public class UserContextController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IUserService _userService;
       
        public UserContextController(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            _userService = userService;
            _userManager = userManager;

        }

        protected UserProfile GetProfile(ClaimsPrincipal user)
        {
            var applicationUser = _userManager.GetUserAsync(user).Result;
            return  _userService.GetserProfileByClaims(applicationUser.Id);
        }
    }
}