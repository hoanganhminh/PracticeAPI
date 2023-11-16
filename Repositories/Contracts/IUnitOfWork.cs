using PracticeAPI.Models;

namespace PracticeAPI.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Customer> CustomerRepository { get; }
        Task SaveChangesAsync();
    }

}
