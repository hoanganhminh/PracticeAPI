using MediatR;
using PracticeAPI.Models.Data.RequestDTO;

namespace PracticeAPI.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public int Id {  get; set; }
        public CategoryRequestDTO CategoryRequestDTO { get; set; }
    }
}