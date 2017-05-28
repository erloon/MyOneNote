using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using MyOneNote.Data;

namespace MyOneNote.EF
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext> where TContext: MyOneNoteContext
    {
        private readonly TContext _context;
        private bool disposed = false;
        private Dictionary<Type, object> repositories;


        public UnitOfWork(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            //var connection = _context.Database.GetDbConnection();
            //if (_context.Model.Relational() is RelationalModelAnnotations relational)
            //{
            //    relational.DatabaseName = connection.Database;
            //}

            //var items = _context.Model.GetEntityTypes();
            //foreach (var item in items)
            //{
            //    if (item.Relational() is RelationalEntityTypeAnnotations extensions)
            //    {
            //        extensions.Schema = connection.Database;
            //    }
            //}
        }

        
        public TContext DbContext => _context;

       
        public void ChangeDatabase(string database)
        {
            if (_context.Model.Relational() is RelationalModelAnnotations relational)
            {
                relational.DatabaseName = database;
            }

            var connection = _context.Database.GetDbConnection();
            if (connection.State.HasFlag(ConnectionState.Open))
            {
                connection.ChangeDatabase(database);
            }

            // Following code only working for mysql.
            var items = _context.Model.GetEntityTypes();
            foreach (var item in items)
            {
                if (item.Relational() is RelationalEntityTypeAnnotations extensions)
                {
                    extensions.Schema = database;
                }
            }
        }

       
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)repositories[type];
        }

       
        public int ExecuteSqlCommand(string sql, params object[] parameters) => _context.Database.ExecuteSqlCommand(sql, parameters);

        
        public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class => _context.Set<TEntity>().FromSql(sql, parameters);

        
        public int SaveChanges(bool ensureAutoHistory = false)
        {
            //TODO

            return _context.SaveChanges();
        }

        
        public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
        {
            //TODO 

            return await _context.SaveChangesAsync();
        }

        
        public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false, params IUnitOfWork[] unitOfWorks)
        {
            // TransactionScope will be included in .NET Core v1.2
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var count = 0;
                    foreach (var unitOfWork in unitOfWorks)
                    {
                        var uow = unitOfWork as UnitOfWork<MyOneNoteContext>;
                        uow.DbContext.Database.UseTransaction(transaction.GetDbTransaction());
                        count += await uow.SaveChangesAsync(ensureAutoHistory);
                    }

                    count += await SaveChangesAsync(ensureAutoHistory);

                    transaction.Commit();

                    return count;
                }
                catch (Exception ex)
                {

                    transaction.Rollback();

                    throw ex;
                }
            }
        }

       
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // clear repositories
                    if (repositories != null)
                    {
                        repositories.Clear();
                    }

                    // dispose the db context.
                    _context.Dispose();
                }
            }

            disposed = true;
        }
    }
}