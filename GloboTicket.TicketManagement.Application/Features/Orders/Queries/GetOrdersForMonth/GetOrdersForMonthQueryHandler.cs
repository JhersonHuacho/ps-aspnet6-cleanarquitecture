using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth;
public class GetOrdersForMonthQueryHandler : IRequestHandler<GetOrdersForMonthQuery, PagedOrdersForMonthVm>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersForMonthQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<PagedOrdersForMonthVm> Handle(GetOrdersForMonthQuery request, CancellationToken cancellationToken)
    {
        var list = await _orderRepository.GetPagedOrdersForMonth(request.Date, request.Page, request.Size);
        var ordersForMonth = _mapper.Map<List<OrderForMonthDto>>(list);

        var count = await _orderRepository.GetTotalCountOfOrdersForMonth(request.Date);

        return new PagedOrdersForMonthVm()
        {
            Count = count,
            OrdersForMonth = ordersForMonth,
            Page = request.Page,
            Size = request.Size
        };
    }
}
