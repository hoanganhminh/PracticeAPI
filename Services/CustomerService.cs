using AutoMapper;
using PracticeAPI.Models;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services.Contracts;

namespace PracticeAPI.Services
{
    public class CustomerService :ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                var Customers = await _customerRepository.GetAllCustomers();
                return Customers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
