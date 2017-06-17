using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyOneNote.EF
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void ChangeTable(string table)
        {
            if (_dbContext.Model.FindEntityType(typeof(TEntity)).Relational() is RelationalEntityTypeAnnotations relational)
            {
                relational.TableName = table;
            }
        }

       
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, bool disableTracking = true)
        {
            if (disableTracking)
            {
                return _dbSet.AsNoTracking().Where(predicate);
            }
            else
            {
                return _dbSet.Where(predicate);
            }
        }

        
        public IQueryable<TEntity> FromSql(string sql, params object[] parameters) => _dbSet.FromSql(sql, parameters);


        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }


        public Task<TEntity> FindAsync(params object[] keyValues) => _dbSet.FindAsync(keyValues);


        public Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken) => _dbSet.FindAsync(keyValues, cancellationToken);

       
        public TEntity Insert(TEntity entity)
        {
            return _dbSet.Add(entity) as TEntity;
        }

        
        public void Insert(params TEntity[] entities) => _dbSet.AddRange(entities);

       
        public void Insert(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

      
        public Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbSet.AddAsync(entity, cancellationToken);

            // Shadow properties?
            //var property = _dbContext.Entry(entity).Property("Created");
            //if (property != null) {
            //property.CurrentValue = DateTime.Now;
            //}
        }

       
        public Task InsertAsync(params TEntity[] entities) => _dbSet.AddRangeAsync(entities);

       
        public Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken)) => _dbSet.AddRangeAsync(entities, cancellationToken);

       
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);

            // Shadow properties?
            //var property = _dbContext.Entry(entity).Property("LastUpdated");
            //if(property != null) {
            //property.CurrentValue = DateTime.Now;
            //}
        }

        
        public void Update(params TEntity[] entities) => _dbSet.UpdateRange(entities);


        public void Update(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);


        public void Delete(TEntity entity) => _dbSet.Remove(entity);


        public void Delete(object id)
        {
            var typeInfo = typeof(TEntity).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo.Name).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<TEntity>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                {
                    Delete(entity);
                }
            }
        }

 
        public void Delete(params TEntity[] entities) => _dbSet.RemoveRange(entities);

       
        public void Delete(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public DbContext GetContext()
        {
            return _dbContext;
        }
    }
}