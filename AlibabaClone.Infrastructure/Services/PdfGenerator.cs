using AlibabaClone.Application.Interfaces;
using AlibabaClone.Domain.Aggregates.TransportationAggregates;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Net.Sockets;

namespace AlibabaClone.Infrastructure.Services
{
    public class PdfGenerator : IPdfGenerator
    {
        public byte[] GenerateTicketsPdf(TicketOrder ticketOrder)
        {
            var document = new TicketOrderDocument(ticketOrder);

            using var stream = new MemoryStream();
            try
            {

                document.GeneratePdf(stream);
                //document.ShowInCompanion();
                //document.ShowInCompanion();   
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return stream.ToArray();
        }

        static IContainer CellStyle(IContainer container) =>
    container.Padding(5).AlignMiddle().AlignLeft();

    }


public class TicketOrderDocument : IDocument
    {
        public TicketOrder TicketOrder { get; }

        public TicketOrderDocument(TicketOrder ticketOrder)
        {
            TicketOrder = ticketOrder;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            foreach(Ticket ticket in TicketOrder.Tickets)
            {

            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.DefaultTextStyle(x => x.FontSize(12).FontColor(Colors.Black));

                page.Content().Column(column =>
                {
                    column.Item().Text($"Order #{TicketOrder.Id}")
                        .FontSize(17).Bold().FontColor(Colors.Blue.Darken2);

                    //column.Item();

                    // Table: display each ticket in a row
                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(60);         // Ticket #
                            columns.RelativeColumn();           // From → To
                            columns.ConstantColumn(40);         // Seat
                            columns.ConstantColumn(90);         // Date/Time
                            columns.ConstantColumn(50);         // Price
                        });

                        // Header row
                        table.Header(header =>
                        {
                            header.Cell().Element(HeaderStyle).Text("Ticket #");
                            header.Cell().Element(HeaderStyle).Text("Route");
                            header.Cell().Element(HeaderStyle).Text("Seat");
                            header.Cell().Element(HeaderStyle).Text("Date/Time");
                            header.Cell().Element(HeaderStyle).Text("Price");
                        });

                        // Data rows
                            var t = TicketOrder.Transportation;
                            string route = $"{t.FromLocation.City.Title} → {t.ToLocation.City.Title}";
                            string seat = $"{ticket.Seat.Id}";
                            string dt = $"{t.StartDateTime:yyyy/MM/dd HH:mm:ss}";
                            string price = $"{t.BasePrice:C}";

                            table.Cell().Element(CellStyle).Text(ticket.SerialNumber.Substring(0,5));
                            table.Cell().Element(CellStyle).Text(route);
                            table.Cell().Element(CellStyle).Text(seat);
                            table.Cell().Element(CellStyle).Text(dt);
                            table.Cell().Element(CellStyle).Text(price).AlignRight();
                    });

                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(HeaderStyle).Text("Full Name");
                            header.Cell().Element(HeaderStyle).Text("Phone Number");
                            header.Cell().Element(HeaderStyle).Text("National Id");
                        });


                        table.Cell().Element(CellStyle).Text($"{ticket.Traveler.FirstName} {ticket.Traveler.LastName}");
                        table.Cell().Element(CellStyle).Text($"{ticket.Traveler.PhoneNumber}");
                        table.Cell().Element(CellStyle).Text($"{ticket.Traveler.IdNumber}");
                    });

                });

            });
            }
        }

        static IContainer HeaderStyle(IContainer container) =>
            container.Padding(5)
                     //.BorderBottom(1)
                     .BorderColor(Colors.Grey.Lighten2)
                     .DefaultTextStyle(x => x.Bold());
        static IContainer CellStyle(IContainer container) =>
            container.Padding(5)
                     .BorderBottom(1)
                     .BorderColor(Colors.Grey.Lighten2)
                     .DefaultTextStyle(x => x.Bold());
    }

}
