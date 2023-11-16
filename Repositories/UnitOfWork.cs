using PracticeAPI.Models;
using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyStoreContext _context;

        public UnitOfWork(MyStoreContext context)
        {
            _context = context;
            CategoryRepository = new GenericRepository<Category>(_context);
            ProductRepository = new GenericRepository<Product>(_context);
            CustomerRepository = new GenericRepository<Customer>(_context);
        }

        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<Product> ProductRepository { get; }
        public IGenericRepository<Customer> CustomerRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
