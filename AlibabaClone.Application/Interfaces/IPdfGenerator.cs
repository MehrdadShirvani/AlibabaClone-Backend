using AlibabaClone.Domain.Aggregates.TransportationAggregates;

namespace AlibabaClone.Application.Interfaces
{
    public interface IPdfGenerator
    {
        byte[] GenerateTicketsPdf(TicketOrder ticketOrder);
    }
}
