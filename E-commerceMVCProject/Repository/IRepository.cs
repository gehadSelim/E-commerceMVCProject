using System.Linq.Expressions;

namespace E_commerceMVCProject.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
