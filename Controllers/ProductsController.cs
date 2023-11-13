using MediatR;
using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Features.Product.Commands.CreateProduct;
using PracticeAPI.Features.Product.Commands.DeleteProduct;
using PracticeAPI.Features.Product.Commands.UpdateProduct;
using PracticeAPI.Features.Product.Queries.GetAllProducts;
using PracticeAPI.Features.Product.Queries.GetProductById;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetProducts()
        {
            try
            {
                var response = await _mediator.Send(new GetAllProductsQuery());
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProduct(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery { Id = id});
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestDTO productRequestDTO)
        {
            try
            {
                await _mediator.Send(new UpdateProductCommand { ProductRequestDTO = productRequestDTO});
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error updating product: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductRequestDTO productRequestDTO)
        {
            try
            {
                var createdProduct = _mediator.Send(new CreateProductCommand { ProductRequestDTO = productRequestDTO });
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error creating product: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _mediator.Send(new DeleteProductCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error deleting product: {ex.Message}");
            }
        }

    }
}
