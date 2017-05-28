using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyOneNote.Data;

namespace MyOneNote.EF
{
    public static class UnitOfWorkServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : MyOneNoteContext
        {
            services.AddScoped<IRepositoryFactory, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();

            return services;
        }

        
        public static IServiceCollection AddUnitOfWork<TContext1, TContext2>(this IServiceCollection services)
            where TContext1 : MyOneNoteContext
            where TContext2 : MyOneNoteContext
        {
            services.AddScoped<IUnitOfWork<TContext1>, UnitOfWork<TContext1>>();
            services.AddScoped<IUnitOfWork<TContext2>, UnitOfWork<TContext2>>();

            return services;
        }

      
        public static IServiceCollection AddUnitOfWork<TContext1, TContext2, TContext3>(this IServiceCollection services)
            where TContext1 : MyOneNoteContext
            where TContext2 : MyOneNoteContext
            where TContext3 : MyOneNoteContext
        {
            services.AddScoped<IUnitOfWork<TContext1>, UnitOfWork<TContext1>>();
            services.AddScoped<IUnitOfWork<TContext2>, UnitOfWork<TContext2>>();
            services.AddScoped<IUnitOfWork<TContext3>, UnitOfWork<TContext3>>();

            return services;
        }

        
        public static IServiceCollection AddUnitOfWork<TContext1, TContext2, TContext3, TContext4>(this IServiceCollection services)
            where TContext1 : MyOneNoteContext
            where TContext2 : MyOneNoteContext
            where TContext3 : MyOneNoteContext
            where TContext4 : MyOneNoteContext
        {
            services.AddScoped<IUnitOfWork<TContext1>, UnitOfWork<TContext1>>();
            services.AddScoped<IUnitOfWork<TContext2>, UnitOfWork<TContext2>>();
            services.AddScoped<IUnitOfWork<TContext3>, UnitOfWork<TContext3>>();
            services.AddScoped<IUnitOfWork<TContext4>, UnitOfWork<TContext4>>();

            return services;
        }
    }
}