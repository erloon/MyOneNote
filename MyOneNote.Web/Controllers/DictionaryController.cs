using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MyOneNote.API.Infrastructure;
using MyOneNote.Data;
using MyOneNote.Data.Entity;
using MyOneNote.Services;
using MyOneNote.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyOneNote.API.Controllers
{

    [Route("api/[controller]")]
    public class DictionaryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IProjectService _projectService;
        public DictionaryController(
            UserManager<ApplicationUser> userManager,
            IUserService userService,
            IProjectService projectService , 
            ICategoryService categoryService ):base(userManager,userService)
        {
            _categoryService = categoryService;
            _projectService = projectService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(JsonConvert.SerializeObject("sasasasasas"));
        }

        [HttpPost]
        public  IActionResult Category([FromBody]AddCategoryVM categoryVm)
        {
            Category category = null; 
            try
            {
               category = _categoryService.Add(Mapper.Map<Category>(categoryVm));
               category.UserProfile = this.UserProfile;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToInvariantString());
            }
            return Ok(JsonConvert.SerializeObject(Mapper.Map<CategoryVM>(category)));
        }

    }
}