using AutoMapper;
using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoryQueryHandler : BaseService, IRequestHandler<GetAllCategoryQuery, List<CategoryResponseDTO>>
    {
        public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<List<CategoryResponseDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll();
            return _mapper.Map<List<CategoryResponseDTO>>(categories);
        }
    }
}
