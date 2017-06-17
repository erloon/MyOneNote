using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.CodeAnalysis;
using MyOneNote.Data;
using MyOneNote.Data.Entity;
using MyOneNote.Services;
using MyOneNote.ViewModels.Dictionary;
using MyOneNote.ViewModels.Note;
using MyOneNote.WWW.Infrastructure;
using MyOneNote.WWW.Models;
using Project = MyOneNote.Data.Entity.Project;

namespace MyOneNote.WWW.Controllers
{
    public class NoteController:UserContextController
    {
        private readonly INoteService _noteService;
        private readonly ICategoryService _categoryService;
        private readonly IProjectService _projectService;
        private readonly ITagService _tagService;

        public NoteController(UserManager<ApplicationUser> userManager, IUserService userService
            , INoteService noteService
            , IProjectService projectService
            , ICategoryService categoryService
            , ITagService tagService) : base(userManager, userService)
        {
            _noteService = noteService ?? throw new ArgumentException(nameof(noteService));
            _categoryService = categoryService ?? throw new ArgumentException(nameof(categoryService));
            _projectService = projectService ?? throw new ArgumentException(nameof(projectService));
            _tagService = tagService ?? throw new ArgumentException(nameof(tagService));
        }

        public IActionResult AddNote()
        {
            AddNoteVM vm = new AddNoteVM();
            vm.Categories = Mapper.Map<IEnumerable<Category>, List<SelectListItem>>(_categoryService.GetAll());
            vm.Projects = Mapper.Map<IEnumerable<Project>, List<SelectListItem>>(_projectService.GetAll());
            vm.Tags = Mapper.Map<IEnumerable<Tag>, List<SelectListItem>>(_tagService.GetAll());
            return View(vm);
        }
        public IActionResult Note()
        {
            IEnumerable<ListNoteVM> list = null;
            try
            {
                var noteList = _noteService.GetAll();
                list = Mapper.Map<IEnumerable<Note>, IEnumerable<ListNoteVM>>(noteList);
            }
            catch (Exception e)
            {
                throw e;
            }

            return View(list);
        }

        public IActionResult Details(string id)
        {
            

            return View();
        }

        public RedirectToActionResult InsertNote(AddNoteVM note)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Note newNote = Mapper.Map<AddNoteVM, Note>(note);
                    newNote.CreateBy = GetProfile(this.User).Id;
                    newNote.CreationDate =DateTime.Now;
                    _noteService.Add(newNote);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return RedirectToAction("Note");
        }

        public IActionResult Menage()
        {
            IEnumerable<ListNoteVM> list = null;
            try
            {
                var noteList = _noteService.GetAll();
                list = Mapper.Map<IEnumerable<Note>, IEnumerable<ListNoteVM>>(noteList);
            }
            catch (Exception e)
            {
                throw e;
            }

            return View(list);
        }

        public RedirectToActionResult Delete(string id)
        {
            try
            {
                _noteService.Delete(new Note() { Id = Guid.Parse(id) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Menage");
        }

    }
}