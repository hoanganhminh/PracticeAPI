using AutoMapper;
using MediatR;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : BaseService, IRequestHandler<UpdateCategoryCommand, Unit>
    {
        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            request.CategoryRequestDTO.CategoryId = request.Id;
            var category = _mapper.Map<Models.Category>(request.CategoryRequestDTO);
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
