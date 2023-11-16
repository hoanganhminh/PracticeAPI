using AutoMapper;
using MediatR;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : BaseService, IRequestHandler<UpdateProductCommand, Unit>
    {
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Models.Product>(request.ProductRequestDTO);
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
