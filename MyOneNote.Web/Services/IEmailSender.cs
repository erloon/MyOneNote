﻿using System.Threading.Tasks;

namespace MyOneNote.API.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
