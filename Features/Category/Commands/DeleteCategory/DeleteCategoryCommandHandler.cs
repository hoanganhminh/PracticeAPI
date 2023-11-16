using AutoMapper;
using MediatR;
using PracticeAPI.Models;
using PracticeAPI.Repositories.Contracts;

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
