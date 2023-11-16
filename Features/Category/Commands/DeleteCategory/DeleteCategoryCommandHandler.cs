using AutoMapper;
using MediatR;
using PracticeAPI.Models;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : BaseService, IRequestHandler<DeleteCategoryCommand, Unit>
    {
        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Models.Category category = await _unitOfWork.CategoryRepository.GetById(request.Id);
            if (category != null)
            {
                _unitOfWork.CategoryRepository.Remove(category);
                await _unitOfWork.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
