using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Services.Contracts
{
    public interface IProductService
    {
        public Task<List<ProductResponseDTO>> GetAllProducts();
        public Task<ProductResponseDTO> GetProductById(int id);
        public Task<ProductRequestDTO> CreateProduct(ProductRequestDTO productRequestDTO);
        public Task<bool> UpdateProduct(ProductRequestDTO productRequestDTO);
        public Task<bool> DeleteProduct(int id);
    }
}
