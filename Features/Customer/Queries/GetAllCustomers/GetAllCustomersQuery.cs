using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<CustomerResponseDTO>>
    {
    }
}