using System.Linq.Expressions;

namespace PracticeAPI.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task<T> GetOne(Expression<Func<T, bool>> expression);
        Task<T> GetOneByProperty(string value, string propertyName);
        Task<T> GetOneByProperties(string value1, string propertyName1, string value2, string propertyName2);
        Task<T> GetOneByProperties(string value1, string propertyName1, string value2, string propertyName2, string value3, string propertyName3);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        Task SaveAsync();
    }
}
