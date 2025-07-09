using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Result;

namespace AlibabaClone.Application.Interfaces
{
    public interface ITransportationService
    {
        Task<Result<IEnumerable<TransportationSearchResultDto>>> SearchTransportationsAsync(TransportationSearchRequestDto searchRequest);
        Task<Result<List<TransportationSeatDto>>> GetTransportationSeatsAsync(long transportationId);
    }
}
