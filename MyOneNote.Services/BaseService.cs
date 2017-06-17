using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Internal;
using MyOneNote.Data.Entity;
using MyOneNote.EF;

namespace MyOneNote.Services
{
    public abstract class BaseService<TEntity> :IBaseService<TEntity> where TEntity: class , IEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<TEntity> _baseRepository;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = unitOfWork.GetRepository<TEntity>();
        }

        public void PerformCommand(Action action)
        {
            action();
            _unitOfWork.SaveChanges();
        }

        public TEntity PerformCommand(Func<TEntity> action)
        {
            TEntity entity = action();
            _unitOfWork.SaveChanges();
            return entity;
        }

        public TEntity Add(TEntity entity)
        {
            PerformCommand(() =>
            {
                _baseRepository.Insert(entity);
            });
            return entity;
        }

        public void Delete(TEntity entity)
        {
            PerformCommand(() =>
            {
                _baseRepository.Delete(entity);
            });
            
        }

        public TEntity Update(TEntity entity)
        {
            PerformCommand(() =>
            {
                _baseRepository.Update(entity);
            });
            return entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }



    }
}