using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Helpers.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        ICustomerRepository CustomerRepository { get; }

        Task SaveChangesAsync();
    }

}
