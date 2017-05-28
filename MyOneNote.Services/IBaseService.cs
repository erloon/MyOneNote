using System;
using System.Collections.Generic;
using MyOneNote.Data.Entity;

namespace MyOneNote.Services
{
    public interface IBaseService<TEntity> where TEntity:class ,IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Add(TEntity entity);
        TEntity PerformCommand(Func<TEntity> action);
        void PerformCommand(Action action);
    }
}