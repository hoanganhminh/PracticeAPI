using Microsoft.EntityFrameworkCore;
using PracticeAPI.Models;
using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MyStoreContext _context;
        public CustomerRepository(MyStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                var customers = await _context.Customers.ToListAsync();
                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
