using AutoMapper;
using MediatR;
using Grpc.Core;
using Pacagroup.Trade.Services.gRPC;
using Pacagroup.Trade.Application.UsesCases.Features.Orders.Queries.GetAllOrder;
using Pacagroup.Trade.Application.UsesCases.Features.Orders.Queries.GetOrder;
using Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.CreateOrder;
using Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.UpdateOrder;
using Pacagroup.Trade.Application.UsesCases.Features.Orders.Commands.DeleteOrder;


namespace Pacagroup.Trade.Services.gRPC.Services
{
    public class OrderService : Order.OrderBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public OrderService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public override async Task<GetAllOrderResponse> GetAllOrder(GetAllOrderRequest request, ServerCallContext context)
        {
            // Traigo todas las ordenes mediante el Mediator
            var ordersDTO = await mediator.Send(new GetAllOrderQuery());

            // Creo mi Response y Server Response
            var response = new GetAllOrderResponse();
            var serverResponse = new ServerResponse();

            // Si hay ordenes, mapeo y agrego la Data al response
            if (ordersDTO != null && ordersDTO.Any())
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Orders found";
                response.Data.AddRange(mapper.Map<List<OrderResponse>>(ordersDTO));
            }
            else
            {
                serverResponse.Message = "Orders not found";
            }

            response.Response = serverResponse;
            return response;
        }

        public override async Task<GetOrderResponse> GetOrder(GetOrderRequest request, ServerCallContext context)
        {
            var order = await mediator.Send(new GetOrderQuery { Id = request.Id });
            var response = new GetOrderResponse();
            var serverResponse = new ServerResponse();

            if (order != null)
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Order found";
                response.Data = mapper.Map<OrderResponse>(order);
            }
            else
            {
                serverResponse.IsSuccess = false;
                serverResponse.Message = "Order not found";
            }
            response.Response = serverResponse;
            return response;
        }

        public override async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request, ServerCallContext context)
        {
            // Convierto mi Request en un Command
            var createOrderCommand = mapper.Map<CreateOrderCommand>(request);
            // Verifico si el resultado es exitoso
            var status = await mediator.Send(createOrderCommand);

            var response = new CreateOrderResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                var orderDTO = await mediator.Send(new GetOrderQuery { Id = request.Id });

                response.Data = mapper.Map<OrderResponse>(orderDTO);
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Order created";
            }
            else
            {
                serverResponse.IsSuccess = false;
                serverResponse.Message = "Order not created";
            }
            response.Response = serverResponse;
            return response;
        }

        public override async Task<UpdateOrderResponse> UpdateOrder(UpdateOrderRequest request, ServerCallContext context)
        {
            var updateCommand = mapper.Map<UpdateOrderCommand>(request);
            var status = await mediator.Send(updateCommand);

            var response = new UpdateOrderResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                var orderDTO = await mediator.Send(new GetOrderQuery { Id = request.Id });
                response.Data = mapper.Map<OrderResponse>(orderDTO);
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Order updated";
            }
            else
            {
                serverResponse.IsSuccess = false;
                serverResponse.Message = "Order not updated";
            }
            response.Response = serverResponse;
            return response;
        }

        public override async Task<DeleteOrderResponse> DeleteOrder(DeleteOrderRequest request, ServerCallContext context)
        {
            var deleteCommand = new DeleteOrderCommand { Id = request.Id };
            var status = await mediator.Send(deleteCommand);
            var response = new DeleteOrderResponse();
            var serverResponse = new ServerResponse();
            if (status)
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Order deleted";
            }
            else
            {
                serverResponse.IsSuccess = false;
                serverResponse.Message = "Order not deleted";
            }
            response.Response = serverResponse;
            return response;
        }
    }
}
