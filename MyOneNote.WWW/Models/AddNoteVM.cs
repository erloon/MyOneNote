using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyOneNote.ViewModels.Tag;

namespace MyOneNote.WWW.Models
{
    public class AddNoteVM
    {
        public string Title { get; set; }
        public Guid ProjectId { get; set; }
        public List<SelectListItem> Projects { get; set; }
        public Guid CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public Guid[] TagsIds { get; set; }
        public List<SelectListItem> Tags { get; set; }
    }
}