using AB12.Domain.Base.Schema;
using AB12.Services.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AB12.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderService _service;

        public OrderController(ILogger<OrderController> logger, OrderService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var result = await _service.GetListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting list of orders");
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting order by id");
                throw;
            }
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] Order order)
        {
            try
            {
                var result = await _service.CreateAsync(order);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting error while creating order");
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id ,[FromBody] Order order)
        {
            try
            {
                if (id != order.ID)
                {
                    return BadRequest();
                }

                var result = await _service.UpdateAsync(order);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting error while updating order");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                var order = await _service.GetByIdAsync(id);

                if (order == null)
                {
                    return NotFound();
                }

                await _service.DeleteAsync(order);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting error while deleting order");
                throw;
            }
        }
    }
}
