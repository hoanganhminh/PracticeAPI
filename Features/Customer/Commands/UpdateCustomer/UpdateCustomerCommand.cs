using MediatR;
using PracticeAPI.Models.Data.RequestDTO;

namespace PracticeAPI.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public CustomerRequestDTO CustomerRequestDTO { get; set; }
    }
}