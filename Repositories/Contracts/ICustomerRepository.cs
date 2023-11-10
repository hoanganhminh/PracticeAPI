using PracticeAPI.Models;

namespace PracticeAPI.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomers();
    }
}
