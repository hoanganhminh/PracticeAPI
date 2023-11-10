using AutoMapper;
using PracticeAPI.Models;
using PracticeAPI.Repositories;
using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Helpers.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyStoreContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(MyStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            CategoryRepository = new CategoryRepository(_context, _mapper);
            ProductRepository = new ProductRepository(_context, _mapper);
        }

        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
