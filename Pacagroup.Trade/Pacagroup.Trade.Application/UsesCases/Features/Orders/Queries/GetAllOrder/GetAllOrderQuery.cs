using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Trade.Application.UsesCases.Features.Orders.Queries.GetAllOrder
{
    public sealed record GetAllOrderQuery : IRequest<List<GetAllOrderResponseDTO>>
    {}
}
