using AutoMapper;
using MediatR;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services;

namespace PracticeAPI.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : BaseService, IRequestHandler<DeleteProductCommand, Unit>
    {
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetById(request.Id);
            _unitOfWork.ProductRepository.Remove(product);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
