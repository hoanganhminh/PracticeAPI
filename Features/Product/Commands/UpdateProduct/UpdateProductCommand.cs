using MediatR;
using PracticeAPI.Models.Data.RequestDTO;

namespace PracticeAPI.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public ProductRequestDTO ProductRequestDTO { get; set; }
    }
}