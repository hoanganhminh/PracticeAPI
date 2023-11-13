using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        void UpdateCategory(Category category);
        void AddCategory(Category category);
        void DeleteCategory(int id);
    }
}
