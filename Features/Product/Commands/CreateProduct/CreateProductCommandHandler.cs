using AutoMapper;
using MediatR;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : BaseService, IRequestHandler<CreateProductCommand, Unit>
    {
        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Models.Product>(request.ProductRequestDTO);
            _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
