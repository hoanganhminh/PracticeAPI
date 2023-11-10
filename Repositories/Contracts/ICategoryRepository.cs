using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryResponseDTO>> GetAllCategories();
        Task<CategoryResponseDTO> GetCategoryById(int id);
        void UpdateCategory(CategoryRequestDTO categoryRequestDTO);
        void AddCategory(CategoryRequestDTO categoryRequestDTO);
        void DeleteCategory(int id);
        Task SaveChangesAsync();
    }
}
