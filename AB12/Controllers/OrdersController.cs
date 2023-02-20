using AB12.Domain.Base.Schema;
using AB12.Infrastructure.Components;
using AB12.Services.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AB12.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly OrderService _service;
        private readonly OrderRepo _repo;

        public OrdersController(ILogger<OrdersController> logger, OrderService service, OrderRepo repo)
        {
            _logger = logger;
            _service = service;
            _repo = repo;
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

                if (result == null)
                {
                    return NotFound();
                }

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
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

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
                var order = await _repo.GetByIdAsync(id);

                if (order == null)
                {
                    return NotFound();
                }

                var result = await _service.DeleteAsync(order);

                if (!result)
                {
                    return BadRequest();
                }

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
