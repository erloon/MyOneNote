using Microsoft.AspNetCore.Mvc;
using MyOneNote.Data.Entity;
using MyOneNote.EF;
using MyOneNote.Services;

namespace MyOneNote.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteService;
        public HomeController(INoteService noteService)
        {
            _noteService = noteService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            _noteService.GetAll();
            

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
