using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Features.Customer.Commands.CreateCustomer;
using PracticeAPI.Features.Customer.Commands.DeleteCustomer;
using PracticeAPI.Features.Customer.Commands.UpdateCustomer;
using PracticeAPI.Features.Customer.Queries.GetAllCustomers;
using PracticeAPI.Features.Customer.Queries.GetCustomerById;
using PracticeAPI.Features.Customer.Queries.Login;
using PracticeAPI.Models.Data.RequestDTO;
using PracticeAPI.Models.Data.ResponseDTO;

namespace PracticeAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> GetAllCustomers()
        {
            try
            {
                var customers = await _mediator.Send(new GetAllCustomersQuery());
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetCustomerById(int id)
        {
            try
            {
                var customer = await _mediator.Send(new GetCustomerByIdQuery { CustomerId = id });
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponseDTO>> Login(string email, string password)
        {
            try
            {
                var loginResponseDTO = await _mediator.Send(new LoginQuery { Email = email, Password = password });
                Response.Cookies.Append("jwtToken", loginResponseDTO.Token);
                return loginResponseDTO;
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                await _mediator.Send(new UpdateCustomerCommand { Id = id, CustomerRequestDTO = customerRequestDTO });
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error: {ex.Message}");
            }
        }

        [HttpPost("CreateCustomer")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCustomer(CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                await _mediator.Send(new CreateCustomerCommand { CustomerRequestDTO = customerRequestDTO });
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _mediator.Send(new DeleteCustomerCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"Error: {ex.Message}");
            }
        }
    }
}
