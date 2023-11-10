using MediatR;
using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Features.Category.Commands.CreateCategory;
using PracticeAPI.Features.Category.Commands.DeleteCategory;
using PracticeAPI.Features.Category.Commands.UpdateCategory;
using PracticeAPI.Features.Category.Queries.GetAllCategories;
using PracticeAPI.Features.Category.Queries.GetCategoryById;
using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            try
            {
                var categories = await _mediator.Send(new GetAllCategoryQuery());
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            try
            {
                var category = await _mediator.Send(new GetCategoryByIdQuery { CategoryId = id });
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                await _mediator.Send(new UpdateCategoryCommand { categoryRequestDTO = categoryRequestDTO, id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                await _mediator.Send(new CreateCategoryCommand { CategoryRequestDTO = categoryRequestDTO });
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _mediator.Send(new DeleteCategoryCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error: {ex.Message}");
            }
        }
    }
}
