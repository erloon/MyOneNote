using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyOneNote.WWW.Controllers
{
    public class MediumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}