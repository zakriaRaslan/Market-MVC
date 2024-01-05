using System.Linq.Expressions;

namespace Market.Data.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Remove(T entity);
        void Add(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
