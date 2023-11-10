using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Repositories.Contracts;

namespace PracticeAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyStoreContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(MyStoreContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategories()
        {
            try
            {
                var categories = await _context.Categories
                    .Include(x => x.Products)
                    .ToListAsync();
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
                var category = await _context.Categories.FindAsync(id);
                return _mapper.Map<CategoryResponseDTO>(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCategory(CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryRequestDTO);
                _context.Categories.Update(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddCategory(CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryRequestDTO);
                _context.Categories.Add(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                var category = _context.Categories.Find(id); 
                _context.Categories.Remove(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
