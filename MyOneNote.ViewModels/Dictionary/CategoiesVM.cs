using System.Collections.Generic;

namespace MyOneNote.ViewModels.Dictionary
{
    public class CategoiesVM
    {
        public IEnumerable<CategoryVM> CategoryVm { get; set; }
        public AddCategoryVM AddCategoryVm { get; set; }
    }
}