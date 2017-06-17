using System;
using System.ComponentModel.DataAnnotations;

namespace MyOneNote.ViewModels.Dictionary
{
    public class AddProjectVM
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}