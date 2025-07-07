using AlibabaClone.Application.DTOs.Transportation;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.Application.Result;
using AlibabaClone.Domain.Framework.Interfaces;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.TransportationRepositories;
using AlibabaClone.Domain.Framework.Interfaces.Repositories.VehicleRepositories;
using AutoMapper;

namespace AlibabaClone.Application.Services
{
    public class TransportationService : ITransportationService
    {
        private readonly ITransportationRepository _transportationRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransportationService(
            ITransportationRepository transportationRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ISeatRepository seatRepository)
        {
            _transportationRepository = transportationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _seatRepository = seatRepository;
        }



        public async Task<Result<IEnumerable<TransportationSearchResultDto>>> SearchTransportationsAsync(TransportationSearchRequestDto searchRequest)
        {
            var result = await _transportationRepository.SearchTransportationsAsync(
       vehicleTypeId: searchRequest.VehicleTypeId,
       fromCityId: searchRequest.FromCityId,
       toCityId: searchRequest.ToCityId,
       startDate: searchRequest.StartDate,
       endDate: searchRequest.EndDate);


            if (result.Any())
            {
                var transportationsDto = _mapper.Map<IEnumerable<TransportationSearchResultDto>>(result);
                return Result<IEnumerable<TransportationSearchResultDto>>.Success(transportationsDto);
            }

            return Result<IEnumerable<TransportationSearchResultDto>>.NotFound();
        }

        public async Task<Result<List<TransportationSeatDto>>> GetTransportationSeatsAsync(long transportationId)
        {
            var transportation = await _transportationRepository.GetByIdAsync(transportationId);
            if (transportation == null) return Result<List<TransportationSeatDto>>.Error("Transportation Not Found");
            var result = await _seatRepository.GetSeatsByVehicleId(transportation.VehicleId);


            if (result == null || result.Any())
            {
                var transportationSeatDtos = _mapper.Map<List<TransportationSeatDto>>(result);
                return Result<List<TransportationSeatDto>>.Success(transportationSeatDtos);
            }

            return Result<List<TransportationSeatDto>>.NotFound(null);
        }
    }
}