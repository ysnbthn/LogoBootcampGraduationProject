using BootcampProject.DataAccess.EntityFramework.Repository.Abstracts;
using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BootcampProject.DataAccess.EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, BaseEntity
    {
        public readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            T exist = _unitOfWork.Context.Set<T>().Find(entity.Id);
            if (exist != null)
            {
                exist.IsDeleted = true;
                exist.DeletedAt = DateTime.Now;
                _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public IQueryable<T> Get()
        {
            return _unitOfWork.Context.Set<T>().Where(x => !x.IsDeleted).AsQueryable();
        }

        public T GetById(int id)
        {
            var user = _unitOfWork.Context.Set<T>().Find(id);
            return user;
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
