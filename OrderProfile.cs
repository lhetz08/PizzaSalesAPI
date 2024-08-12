using PizzaSalesAPI.Models;
using AutoMapper;
using PizzaSalesAPI.DTO;

namespace PizzaSalesAPI
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Define your mappings here
            CreateMap<Orders, OrderDto>();
            CreateMap<Orders, OrderCreateDto>();
            CreateMap<OrderCreateDto, Orders>();
            CreateMap<OrderDto, Orders>();
            CreateMap<Pizza, PizzaDto>();
        }
    }
}
