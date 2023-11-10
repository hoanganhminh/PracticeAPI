using AutoMapper;
using MediatR;
using PracticeAPI.Helpers.UnitOfWork;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<List<CategoryResponseDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllCategories();
            return categories;
        }
    }
}
