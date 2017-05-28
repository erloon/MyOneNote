using System;
using System.Collections.Generic;

namespace MyOneNote.ViewModels
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserProfileName { get; set; }
        public Guid CreateBy { get; set; }
        public string Name { get; set; }

     
    }
}