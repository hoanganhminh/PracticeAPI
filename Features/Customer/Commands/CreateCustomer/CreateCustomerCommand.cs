using MediatR;
using PracticeAPI.Models.Data.RequestDTO;

namespace PracticeAPI.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Unit>
    {
        public CustomerRequestDTO CustomerRequestDTO { get; set; }
    }
}