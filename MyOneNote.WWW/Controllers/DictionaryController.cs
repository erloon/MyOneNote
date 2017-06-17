using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using MyOneNote.Data;
using MyOneNote.Data.Entity;
using MyOneNote.Services;
using MyOneNote.ViewModels;
using MyOneNote.ViewModels.Dictionary;
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
        public RedirectToActionResult AddCategory(AddCategoryVM categoryVm)
        {
            if (ModelState.IsValid)
            {
                Category category = null;
                try
                {
                    category = Mapper.Map<Category>(categoryVm);
                    category.CreateBy = GetProfile(this.User).Id;
                    category.CreateDate = DateTime.Now;
                    _categoryService.Add(category);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Category");
        }
        
        public RedirectToActionResult DeleteCategory(string id)
        {
            try
            {
                _categoryService.Delete(new Category(){Id = Guid.Parse(id)});
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Category");
        }
        public RedirectToActionResult DeleteProject(string id)
        {
            try
            {
                _projectService.Delete(new Project() { Id = Guid.Parse(id) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Project");
        }

        [HttpGet]
        public IActionResult Category()
        {
            CategoiesVM vm = new CategoiesVM();
            vm.CategoryVm = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryVM>>(_categoryService.GetAll()); 
            return View(vm);
        }
        [HttpPost]
        public RedirectToActionResult AddProject(AddProjectVM model)
        {
            Project project = null;
            if (ModelState.IsValid)
            {
                try
                {
                    project = Mapper.Map<AddProjectVM, Project>(model);
                    project.UserProfileId = GetProfile(this.User).Id;
                    project.CreateDate = DateTime.Now;
                    _projectService.Add(project);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Project");
        }
        [HttpGet]
        public IActionResult Project()
        {
            ProjectsVM vm = new ProjectsVM();
            vm.ProjectMm = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectVM>>(_projectService.GetAll());
            return View(vm);
        }
    }
}