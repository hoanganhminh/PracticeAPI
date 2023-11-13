using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductResponseDTO>>
    {
    }
}