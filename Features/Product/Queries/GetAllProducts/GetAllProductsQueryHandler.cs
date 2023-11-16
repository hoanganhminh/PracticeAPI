using AutoMapper;
using MediatR;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : BaseService, IRequestHandler<GetAllProductsQuery, List<ProductResponseDTO>>
    {
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<List<ProductResponseDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAll();
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }
    }
}
