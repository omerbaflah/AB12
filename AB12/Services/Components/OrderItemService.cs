using AB12.Application.OrderItems;
using AB12.Domain.Base.Schema;
using AB12.Infrastructure.Components;
using AutoMapper;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace AB12.Services.Components
{
    [ScopedService]
    public class OrderItemService
    {
        private readonly IMapper _mapper;
        private readonly OrderItemRepo _repo;

        public OrderItemService(IMapper mapper, OrderItemRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<OrderItemResults>> GetListAsync()
        {
            var orderItems = await _repo.GetAllAsync();
            return _mapper.Map<List<OrderItemResults>>(orderItems);
        }

        public async Task<OrderItemResults> GetByIdAsync(string id)
        {
            var orderItem = await _repo.GetByIdAsync(id);
            return _mapper.Map<OrderItemResults>(orderItem);
        }

        public async Task<OrderItemResults> CreateAsync(OrderItem entity)
        {
            var orderItem = await _repo.CreateAsync(entity);
            return _mapper.Map<OrderItemResults>(orderItem);
        }

        public async Task<OrderItemResults> UpdateAsync(OrderItem entity)
        {
            var orderItem = await _repo.UpdateAsync(entity);
            return _mapper.Map<OrderItemResults>(orderItem);
        }

        public async Task<bool> DeleteAsync(OrderItem entity)
        {
            return await _repo.DeleteAsync(entity);
        }
    }
}
