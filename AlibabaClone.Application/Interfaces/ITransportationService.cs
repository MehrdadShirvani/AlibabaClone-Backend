using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Application.Interfaces
{
    public interface ITransportationService
    {
        Task<Result<IEnumerable<TransportationSearchResultDto>>> SearchTransportationsAsync(TransportationSearchRequestDto searchRequest);
        Task<Result<List<TransportationSeatDto>>> GetTransportationSeatsAsync(long transportationId);
    }
}
