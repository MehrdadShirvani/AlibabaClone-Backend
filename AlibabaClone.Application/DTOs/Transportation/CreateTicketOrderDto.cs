using System.ComponentModel.DataAnnotations;

namespace AlibabaClone.Application.DTOs.Transportation
{
    public class CreateTicketOrderDto
    {
        public long TransportationId { get; set; }
        public long? CouponId { get; set; }
        public List<CreateTravelerTicketDto> Travelers { get; set; }
    }
}
