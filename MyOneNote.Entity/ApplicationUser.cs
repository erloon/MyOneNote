using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyOneNote.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
