using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Services.Contracts
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponseDTO>> GetAllCategories();
        Task<CategoryResponseDTO> GetCategoryById(int id);
        Task UpdateCategory(int id, CategoryRequestDTO categoryRequestDTO);
        Task CreateCategory(CategoryRequestDTO categoryRequestDTO);
        Task<bool> DeleteCategory(int id);
    }
}
