using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Repositories.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PracticeAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStoreContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MyStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var products = await _context.Products
                    .ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddProduct(ProductRequestDTO productRequestDTO)
        {
            try
            {
                var product = _mapper.Map<Product>(productRequestDTO);
                _context.Products.Add(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(ProductRequestDTO productRequestDTO)
        {
            try
            {
                var product = _mapper.Map<Product>(productRequestDTO);
                _context.Products.Update(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                _context.Products.Remove(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
