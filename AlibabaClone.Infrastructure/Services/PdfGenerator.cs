using AlibabaClone.Application.Interfaces;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace AlibabaClone.Infrastructure.Services
{
    public class PdfGenerator : IPdfGenerator
    {
        public byte[] GenerateTicketsPdf(TicketOrder ticketOrder)
        {
            var document = Document.Create(container =>
        {
            foreach (var ticket in ticketOrder.Tickets)
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.Content().Column(col =>
                    {
                        col.Item().Text($"Ticket: {ticket.SerialNumber}").FontSize(20);
                        col.Item().Text($"Passenger: {ticket.Traveler.FirstName} {ticket.Traveler.LastName}");
                        col.Item().Text($"Seat: {ticket.Seat.Row} - {ticket.Seat.Column}");
                        col.Item().Text($"Trip: {ticketOrder.Transportation.FromLocation.City.Title} {ticketOrder.Transportation.ToLocation.City.Title}");
                    });
                });
            }
        });

            using var stream = new MemoryStream();
            try
            {

            document.GeneratePdf(stream);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return stream.ToArray();
        }
    }
}
