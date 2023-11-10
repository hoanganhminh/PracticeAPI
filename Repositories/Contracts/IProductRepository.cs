using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;

namespace PracticeAPI.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        void AddProduct(ProductRequestDTO productRequestDTO);
        void UpdateProduct(ProductRequestDTO productRequestDTO);
        void DeleteProduct(Product product);
        Task SaveAsync();
    }

}
