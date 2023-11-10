using AutoMapper;
using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Repositories.Contracts;
using PracticeAPI.Services.Contracts;

namespace PracticeAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategories();
                return _mapper.Map<List<CategoryResponseDTO>>(categories);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryResponseDTO> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryById(id);
                return _mapper.Map<CategoryResponseDTO>(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCategory(int id, CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                categoryRequestDTO.CategoryId = id;
                _categoryRepository.UpdateCategory(categoryRequestDTO);
                await _categoryRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CreateCategory(CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                _categoryRepository.AddCategory(categoryRequestDTO);
                await _categoryRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                _categoryRepository.DeleteCategory(id);
                await _categoryRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
