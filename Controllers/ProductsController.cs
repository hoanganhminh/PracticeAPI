using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAPI.Models;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Models.Data.ResponseDTO;
using PracticeAPI.Services;
using PracticeAPI.Services.Contracts;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetProducts()
        {
            try
            {
                var response = await _productService.GetAllProducts();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
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


        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestDTO productRequestDTO)
        {
            if (id != productRequestDTO.ProductId)
            {
                return BadRequest();
            }

            try
            {
                var updatedProduct = await _productService.UpdateProduct(productRequestDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error updating product: {ex.Message}");
            }
        }


        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductRequestDTO productRequestDTO)
        {
            try
            {
                var createdProduct = await _productService.CreateProduct(productRequestDTO);
                return CreatedAtAction("GetProduct", new { id = createdProduct.ProductId }, createdProduct);
            }
            catch (Exception ex)
            {
                return Problem($"Error creating product: {ex.Message}");
            }
        }


        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var deleted = await _productService.DeleteProduct(id);
                if (!deleted)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error deleting product: {ex.Message}");
            }
        }

    }
}
