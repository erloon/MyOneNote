using Microsoft.AspNetCore.Mvc;
using MyOneNote.ViewModels.Medium;

namespace MyOneNote.WWW.Controllers
{
    public class MediumController : Controller
    {
        public IActionResult AddMedium(AddMediumVM model)
        {
            return View("Medium");
        }

        public IActionResult Medium()
        {
            return View();
        }
    }
}