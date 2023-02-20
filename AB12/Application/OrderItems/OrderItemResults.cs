using AB12.Application.Orders.Results;
using AB12.Application.Products.Results;
using AB12.Domain.Base.Schema;
using AB12.Services.Application;
using AutoMapper;

namespace AB12.Application.OrderItems
{
    public class OrderItemResults : IMapFrom<OrderItem>
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public ProductResult Product { get; set; }
        public OrderResult Order { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemResults>()
                .ForMember(dest => dest.Product, act => act.MapFrom(src => src.Product))
                .ForMember(dest => dest.Order, act => act.MapFrom(src => src.Order));
        }
    }
}
