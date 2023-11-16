using AutoMapper;
using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : BaseService, IRequestHandler<GetCategoryByIdQuery, CategoryResponseDTO>
    {
        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<CategoryResponseDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(request.CategoryId);
            return _mapper.Map<CategoryResponseDTO>(category);
        }
    }
}
