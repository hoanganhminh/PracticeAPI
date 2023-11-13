using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductResponseDTO>
    {
        public int Id { get; set; }
    }
}