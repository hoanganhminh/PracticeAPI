using AutoMapper;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services.Contracts;

namespace PracticeAPI.Services
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }

}
