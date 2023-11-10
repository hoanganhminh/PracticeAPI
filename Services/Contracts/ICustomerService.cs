using PracticeAPI.Models;

namespace PracticeAPI.Services.Contracts
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetAllCustomers();
    }
}
