using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PracticeAPI.Models;
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
            var category = _mapper.Map<Models.Category>(request.CategoryRequestDTO);
            _unitOfWork.CategoryRepository.Add(category);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
