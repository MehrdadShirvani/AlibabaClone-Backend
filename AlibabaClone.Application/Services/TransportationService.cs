using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class TransportationService : ITransportationService
    {
        private readonly ITransportationRepository _transportationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransportationService(
            ITransportationRepository transportationRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _transportationRepository = transportationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<IEnumerable<TransportationSearchResultDto>>> SearchTransportationsAsync(TransportationSearchRequestDto searchRequest)
        {
            var result = await _transportationRepository.SearchTransportationsAsync(
       fromCityId: searchRequest.FromCityId,
       toCityId: searchRequest.ToCityId,
       startDate: searchRequest.StartDate,
       endDate: searchRequest.EndDate);
            

            if (result.Any())
            {
                var transportationsDto = _mapper.Map<IEnumerable<TransportationSearchResultDto>>(result);
                return Result<IEnumerable<TransportationSearchResultDto>>.Success(transportationsDto);
            }

            return Result<IEnumerable<TransportationSearchResultDto>>.NotFound(null); 
        }
    }
}