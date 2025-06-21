using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface ITicketOrderService
    {
        public Task<Result<long>> CreateTicketOrderAsync(long accountId,CreateTicketOrderDto createTicketOrderDto);
    }
}
