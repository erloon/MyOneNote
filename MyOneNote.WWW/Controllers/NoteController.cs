using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyOneNote.Data;
using MyOneNote.Services;
using MyOneNote.WWW.Infrastructure;

namespace MyOneNote.WWW.Controllers
{
    public class NoteController:UserContextController
    {

        public NoteController(UserManager<ApplicationUser> userManager, IUserService userService) : base(userManager, userService)
        {
            
        }

        public IActionResult Index()
        {
            
            return View();
        }

        
    }
}