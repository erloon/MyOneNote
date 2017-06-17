using System;

namespace MyOneNote.ViewModels.Dictionary
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserProfileName { get; set; }
        public Guid CreateBy { get; set; }
        public string Name { get; set; }

        public AddCategoryVM AddCategoryVm { get; set; }

     
    }
}