using PracticeAPI.Models;
using PracticeAPI.Repositories;
using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Helpers.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyStoreContext _context;

        public UnitOfWork(MyStoreContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
        }

        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ICustomerRepository CustomerRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
