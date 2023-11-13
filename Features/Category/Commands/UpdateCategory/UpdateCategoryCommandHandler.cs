using AutoMapper;
using MediatR;
using PracticeAPI.Helpers.UnitOfWork;

namespace PracticeAPI.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            request.Id = request.CategoryRequestDTO.CategoryId;
            var category = _mapper.Map<Models.Category>(request.CategoryRequestDTO);
            _unitOfWork.CategoryRepository.UpdateCategory(category);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
