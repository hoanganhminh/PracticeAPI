using Microsoft.EntityFrameworkCore;
using PracticeAPI.Repositories.Contracts;
using System.Linq.Expressions;

namespace PracticeAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> GetOne(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task<T> GetOneByProperty(string value, string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var body = Expression.Equal(property, Expression.Constant(value));
            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return await _dbSet.FirstOrDefaultAsync(lambda);
        }

        public async Task<T> GetOneByProperties(string value1, string propertyName1, string value2, string propertyName2)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property1 = Expression.Property(parameter, propertyName1);
            var property2 = Expression.Property(parameter, propertyName2);
            var body = Expression.AndAlso(
                Expression.Equal(property1, Expression.Constant(value1)),
                Expression.Equal(property2, Expression.Constant(value2))
            );
            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return await _dbSet.FirstOrDefaultAsync(lambda);
        }

        public async Task<T> GetOneByProperties(string value1, string propertyName1, string value2, string propertyName2, string value3, string propertyName3)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property1 = Expression.Property(parameter, propertyName1);
            var property2 = Expression.Property(parameter, propertyName2);
            var property3 = Expression.Property(parameter, propertyName3);
            var body = Expression.AndAlso(
                Expression.AndAlso(
                    Expression.Equal(property1, Expression.Constant(value1)),
                    Expression.Equal(property2, Expression.Constant(value2))
                ),
                Expression.Equal(property3, Expression.Constant(value3))
            );
            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);

            return await _dbSet.FirstOrDefaultAsync(lambda);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
