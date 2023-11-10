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
            if(request.categoryRequestDTO is null)
            {
                throw new ArgumentException("Missing Value");
            }
            request.id = request.categoryRequestDTO.CategoryId;
            _unitOfWork.CategoryRepository.UpdateCategory(request.categoryRequestDTO);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
