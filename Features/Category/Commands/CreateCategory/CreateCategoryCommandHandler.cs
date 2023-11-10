using AutoMapper;
using MediatR;
using PracticeAPI.Helpers.UnitOfWork;
using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.CategoryRepository.AddCategory(request.CategoryRequestDTO);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
