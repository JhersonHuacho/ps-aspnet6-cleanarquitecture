using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Exceptions;
public class BadRequestExceptions : Exception
{
    public BadRequestExceptions(string message): base(message)
    {
        
    }
}
