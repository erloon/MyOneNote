using System.ComponentModel.DataAnnotations;

namespace MyOneNote.ViewModels.Dictionary
{
    public class AddCategoryVM
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100 ,ErrorMessage = "Maksymalna długość nazwy kategori 100 znaków")]
        public string Name { get; set; }
    }
}