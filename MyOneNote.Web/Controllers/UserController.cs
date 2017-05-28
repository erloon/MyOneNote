using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyOneNote.Infrastructure.Exceptions;
using MyOneNote.Services;
using MyOneNote.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyOneNote.API.Controllers
{

    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] JObject model)
        {
            try
            {
                UserRegisterVM userRegisterVm = model.ToObject<UserRegisterVM>();
                var user = await _userService.Register(userRegisterVm);
            }
            catch (RegisterUserException ex)
            {
                BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(model);
        }
    }
}