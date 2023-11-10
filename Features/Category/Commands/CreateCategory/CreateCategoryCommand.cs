using MediatR;
using PracticeAPI.Models.Data.RequestDTO;

namespace PracticeAPI.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public CategoryRequestDTO CategoryRequestDTO { get; set; }
    }
}