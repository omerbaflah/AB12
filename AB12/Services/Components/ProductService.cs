using AB12.Application.Products.Results;
using AB12.Infrastructure.Components;
using AutoMapper;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace AB12.Services.Components
{
    [ScopedService]
    public class ProductService
    {
        private readonly IMapper _mapper;
        private readonly ProductRepo _repo;

        public ProductService(IMapper mapper, ProductRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<ProductResult>> GetListAsync()
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<List<ProductResult>>(products);
        }

        public async Task<ProductResult> GetByIdAsync(string id)
        {
            var product = await _repo.GetByIdAsync(id);
            return _mapper.Map<ProductResult>(product);
        }
    }
}
