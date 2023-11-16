using AutoMapper;
using MediatR;
using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetById(request.Id);
            _unitOfWork.ProductRepository.Remove(product);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
