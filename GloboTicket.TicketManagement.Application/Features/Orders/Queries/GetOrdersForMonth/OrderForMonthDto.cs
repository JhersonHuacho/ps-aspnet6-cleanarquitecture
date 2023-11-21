using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth;
public class OrderForMonthDto
{
    public Guid Id { get; set; }
    public int OrderTotal { get; set; }
    public DateTime OrderPlaced { get; set; }
}
