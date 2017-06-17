using Microsoft.AspNetCore.Mvc;
using MyOneNote.ViewModels.Link;

namespace MyOneNote.WWW.Controllers
{
    public class LinkController : Controller
    {
        public IActionResult AddLink(AddLinkVM model)
        {
            return View();
        }

        public IActionResult Link()
        {
            return View();
        }
    }
}