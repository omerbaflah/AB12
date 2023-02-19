using AB12.Application.Products.Results;
using AB12.Domain.Base.Schema;
using AB12.Infrastructure.Components;
using AutoMapper;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace AB12.Services.Components
{
    [ScopedService]
    public class OrderService
    {
        private readonly IMapper _mapper;
        private readonly OrderRepo _repo;

        public OrderService(IMapper mapper, OrderRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<Order>> GetListAsync()
        {
            var orders = await _repo.GetAllAsync();
            return _mapper.Map<List<Order>>(orders);
        }

        public async Task<Order> GetByIdAsync(string id)
        {
            var order = await _repo.GetByIdAsync(id);
            return _mapper.Map<Order>(order);
        }

        public async Task<Order> CreateAsync(Order entity)
        {
            var order = await _repo.CreateAsync(entity);
            return _mapper.Map<Order>(order);
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            var order = await _repo.UpdateAsync(entity);
            return _mapper.Map<Order>(order);
        }

        public async Task<Order> DeleteAsync(Order entity)
        {
            var order = await _repo.DeleteAsync(entity);
            return _mapper.Map<Order>(order);
        }
    }
}
