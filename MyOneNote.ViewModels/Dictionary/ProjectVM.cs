using System;
using System.ComponentModel.DataAnnotations;

namespace MyOneNote.ViewModels.Dictionary
{
    public class ProjectVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Data utworzenia")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }
    }
}