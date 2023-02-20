using AB12.Application.Orders.Results;
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

        public async Task<List<OrderResult>> GetListAsync()
        {
            var orders = await _repo.GetAllAsync();
            return _mapper.Map<List<OrderResult>>(orders);
        }

        public async Task<OrderResult> GetByIdAsync(string id)
        {
            var order = await _repo.GetByIdAsync(id);
            return _mapper.Map<OrderResult>(order);
        }

        public async Task<OrderResult> CreateAsync(Order entity)
        {
            var order = await _repo.CreateAsync(entity);
            return _mapper.Map<OrderResult>(order);
        }

        public async Task<OrderResult> UpdateAsync(Order entity)
        {
            var order = await _repo.UpdateAsync(entity);
            return _mapper.Map<OrderResult>(order);
        }

        public async Task<bool> DeleteAsync(Order entity)
        {
            return await _repo.DeleteAsync(entity);
        }
    }
}
