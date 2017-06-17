using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyOneNote.EF
{
    public interface IRepository<TEntity> where TEntity : class
    {
        
        void ChangeTable(string table);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, bool disableTracking = true);
        IQueryable<TEntity> FromSql(string sql, params object[] parameters);
        TEntity Find(params object[] keyValues);
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken);
        TEntity Insert(TEntity entity);
        void Insert(params TEntity[] entities);
        void Insert(IEnumerable<TEntity> entities);
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task InsertAsync(params TEntity[] entities);
        Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));  
        void Update(TEntity entity);
        void Update(params TEntity[] entities);
        void Update(IEnumerable<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entity);
        void Delete(params TEntity[] entities);
        void Delete(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> GetAll();
        DbContext GetContext();
    }
}