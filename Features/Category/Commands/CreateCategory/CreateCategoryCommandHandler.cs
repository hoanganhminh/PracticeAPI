using AutoMapper;
using MediatR;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;
using PracticeAPI.Services.Contracts;

namespace PracticeAPI.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : BaseService, IRequestHandler<CreateCategoryCommand, Unit>
    {
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Models.Category>(request.CategoryRequestDTO);
            _unitOfWork.CategoryRepository.Add(category);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
