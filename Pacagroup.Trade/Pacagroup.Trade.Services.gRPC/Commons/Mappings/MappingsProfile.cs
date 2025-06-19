using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Pacagroup.Trade.Application.UsesCases.Features.Orders.Queries.GetAllOrder;
using Pacagroup.Trade.Application.UsesCases.Features.Orders.Queries.GetOrder;
using Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.CreateOrder;
using Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.UpdateOrder;
using Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.DeleteOrder;

namespace Pacagroup.Trade.Services.gRPC.Commons.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));
            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x.ToDateTime());


            CreateMap<CreateOrderCommand, CreateOrderRequest>().ReverseMap();
            CreateMap<UpdateOrderCommand, UpdateOrderRequest>().ReverseMap();
            CreateMap<OrderResponse, GetOrderResponseDTO>().ReverseMap()
                .ForMember(dest => dest.Currency, opt => opt.Condition(src => src.Currency != null))
                .ForMember(dest => dest.Text, opt => opt.Condition(src => src.Text != null));
            CreateMap<OrderResponse, GetAllOrderResponseDTO>().ReverseMap()
                .ForMember(dest => dest.Currency, opt => opt.Condition(src => src.Currency != null))
                .ForMember(dest => dest.Text, opt => opt.Condition(src => src.Text != null)); 
        }
    }
}
