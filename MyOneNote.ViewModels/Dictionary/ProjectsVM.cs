using System;
using System.Collections.Generic;

namespace MyOneNote.ViewModels.Dictionary
{
    public class ProjectsVM
    {
        
        public IEnumerable<ProjectVM> ProjectMm { get; set; }
        public AddProjectVM AddProjectVM { get; set; }
    }
}