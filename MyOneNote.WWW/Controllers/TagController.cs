using Microsoft.AspNetCore.Mvc;
using MyOneNote.ViewModels.Tag;

namespace MyOneNote.WWW.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Tag()
        {
            return View();
        }

        public IActionResult Tag(AddTagVM model)
        {
            return View("Tag");
        }
    }
}