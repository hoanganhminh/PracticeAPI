using MediatR;
using PracticeAPI.Models.Data.RequestDTO;

namespace PracticeAPI.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public int id {  get; set; }
        public CategoryRequestDTO categoryRequestDTO { get; set; }
    }
}