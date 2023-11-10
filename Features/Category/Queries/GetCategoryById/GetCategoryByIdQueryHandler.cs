using AutoMapper;
using MediatR;
using PracticeAPI.Helpers.UnitOfWork;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<CategoryResponseDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetCategoryById(request.CategoryId);
            return category;
        }
    }
}
