﻿using System.ComponentModel.DataAnnotations;

namespace MyOneNote.API.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
