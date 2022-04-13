using System.Linq;

namespace BootcampProject.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IRepository<T> where T : class 
    {
        IQueryable<T> Get();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    
}
