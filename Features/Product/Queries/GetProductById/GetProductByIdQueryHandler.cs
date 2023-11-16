using AutoMapper;
using MediatR;
using PracticeAPI.Features.Product.Queries.GetAllProducts;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : BaseService, IRequestHandler<GetProductByIdQuery, ProductResponseDTO>
    {
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<ProductResponseDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetById(request.Id);
            return _mapper.Map<ProductResponseDTO>(product);
        }
    }
}
