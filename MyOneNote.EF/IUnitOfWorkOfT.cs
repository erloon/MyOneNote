using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyOneNote.Data;

namespace MyOneNote.EF
{
    public interface IUnitOfWork<TContext> : IUnitOfWork
    {
        TContext DbContext { get; }

        
        Task<int> SaveChangesAsync(bool ensureAutoHistory = false, params IUnitOfWork[] unitOfWorks);
    }
}