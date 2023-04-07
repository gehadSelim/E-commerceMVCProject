using System.Linq.Expressions;

namespace E_commerceMVCProject.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T GetByIdWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
