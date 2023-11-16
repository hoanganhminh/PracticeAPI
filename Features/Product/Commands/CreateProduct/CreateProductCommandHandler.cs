using AutoMapper;
using MediatR;
using PracticeAPI.Features.Category.Commands.CreateCategory;
using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Models.Product>(request.ProductRequestDTO);
            _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
