using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyOneNote.Data;
using MyOneNote.Data.Entity;
using MyOneNote.Services;
using MyOneNote.ViewModels;
using MyOneNote.WWW.Infrastructure;
using Newtonsoft.Json;

namespace MyOneNote.WWW.Controllers
{
    public class DictionaryController : UserContextController
    {
        private readonly ICategoryService _categoryService;
        private readonly IProjectService _projectService;

        public DictionaryController(
            UserManager<ApplicationUser> userManager,
            IUserService userService,
            IProjectService projectService,
            ICategoryService categoryService):base(userManager,userService)
        {
            _categoryService = categoryService;
            _projectService = projectService;
        }

        [HttpPost]
        public IActionResult Category(AddCategoryVM categoryVm)
        {
            Category category = null;
            try
            {
                category = _categoryService.Add(Mapper.Map<Category>(categoryVm));
                category.UserProfile = GetProfile(this.User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToInvariantString());
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Category()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Project(ProjectVM model)
        {
            Project project = null;

            try
            {
                project = _projectService.Add(Mapper.Map<Category>(model));
                project.UserProfile = GetProfile(this.User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToInvariantString());
            }
            return View(project);
        }
        [HttpPost]
        public IActionResult Project()
        {
            List<ProjectVM> projects = _projectService.GetAll().ToList();
            return View();
        }
    }
}