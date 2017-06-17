using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyOneNote.ViewModels.Rating;

namespace MyOneNote.WWW.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult AddRating(AddRatingVM model)
        {
            return View("Rating");
        }

        public IActionResult Rating()
        {
            return View();
        }
    }
}