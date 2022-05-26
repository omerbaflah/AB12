using AB12.Services.Application;
using AB12.Domain.Base.Schema;
using AutoMapper;

namespace AB12.Application.Products.Results
{
    public class ProductResult : IMapFrom<Product>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductResult>();
        }
    }
}
