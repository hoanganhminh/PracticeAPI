using AutoMapper;
using MediatR;
using PracticeAPI.Helpers.UnitOfWork;

namespace PracticeAPI.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            _unitOfWork.CategoryRepository.DeleteCategory(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
