using Microsoft.AspNetCore.Mvc;
using MyOneNote.ViewModels;
using MyOneNote.ViewModels.Review;

namespace MyOneNote.WWW.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Review(AddReviewVM model)
        {
            return View("Review");
        }

        public IActionResult Review()
        {
            return View();
        }
    }
}