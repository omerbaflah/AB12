using AB12.Domain.Base.Schema;
using AB12.Infrastructure.Components;
using AB12.Services.Components;
using Microsoft.AspNetCore.Mvc;

namespace AB12.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly ILogger<OrderItemsController> _logger;
        private readonly OrderItemService _service;
        private readonly OrderItemRepo _repo;

        public OrderItemsController(ILogger<OrderItemsController> logger, OrderItemService service, OrderItemRepo repo)
        {
            _logger = logger;
            _service = service;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var result = await _service.GetListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting list of order items");
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting order item by id");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrderItem orderItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _service.CreateAsync(orderItem);

                if (result == null)
                {
                    return BadRequest();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting error while creating order item");
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] OrderItem orderItem)
        {
            try
            {
                if (id != orderItem.ID)
                {
                    return BadRequest();
                }

                var result = await _service.UpdateAsync(orderItem);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting error while updating order item");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                var orderItem = await _repo.GetByIdAsync(id);

                if (orderItem == null)
                {
                    return NotFound();
                }

                var result = await _service.DeleteAsync(orderItem);

                if (!result)
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting error while deleting order item");
                throw;
            }
        }
    }
}
