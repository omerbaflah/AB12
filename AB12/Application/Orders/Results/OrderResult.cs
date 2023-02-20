using AB12.Services.Application;
using AB12.Domain.Base.Schema;
using AutoMapper;

namespace AB12.Application.Orders.Results
{
    public class OrderResult : IMapFrom<Order>
    {
        public string Id { get; set; }
        public string ClientName { get; set; }
        public string Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderResult>();
        }
    }
}
