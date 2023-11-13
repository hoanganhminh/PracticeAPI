using MediatR;
using PracticeAPI.Models.Data.RequestDTO;

namespace PracticeAPI.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public ProductRequestDTO ProductRequestDTO { get; set; }
    }
}