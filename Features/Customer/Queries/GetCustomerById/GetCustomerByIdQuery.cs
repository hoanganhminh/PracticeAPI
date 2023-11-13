using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponseDTO>
    {
        public int CustomerId { get; set; }
    }
}