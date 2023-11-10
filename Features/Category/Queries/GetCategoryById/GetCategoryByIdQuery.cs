using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryResponseDTO>
    {
        public int CategoryId { get; set; }
    }
}
