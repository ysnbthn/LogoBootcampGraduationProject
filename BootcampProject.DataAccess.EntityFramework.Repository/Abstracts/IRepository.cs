using BootcampProject.Domain.Entities;
using System.Linq;

namespace BootcampProject.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IRepository<T> where T : class, BaseEntity 
    {
        IQueryable<T> Get();
        T GetById(string id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    
}
