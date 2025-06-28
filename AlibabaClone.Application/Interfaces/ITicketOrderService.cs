using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface ITicketOrderService
    {
        Task<Result<long>> CreateTicketOrderAsync(long accountId,CreateTicketOrderDto createTicketOrderDto);
        Task<Result<byte[]>> GenerateTicketsPdfAsync(long accountId, long ticketOrderId);
    }
}
