using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoryQuery : IRequest<List<CategoryResponseDTO>>
    {
    }
}