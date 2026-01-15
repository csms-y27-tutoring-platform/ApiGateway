using ApiGateway.Application.Models.Bookings.Payloads;

namespace ApiGateway.Infrastructure.Grpc.Mappings.Booking;

public static class BookingHistoryPayloadMapper
{
    public static Application.Models.Bookings.Payloads.BookingHistoryPayload ToApplication(
        this BookingHistoryPayload bookingHistoryPayload)
    {
        Application.Models.Bookings.Payloads.BookingHistoryPayload payload = bookingHistoryPayload.PayloadCase switch
        {
            BookingHistoryPayload.PayloadOneofCase.Created => new BookingHistoryPayloadCreated(bookingHistoryPayload
                .Created.CreatedBy),
            BookingHistoryPayload.PayloadOneofCase.Cancelled => new BookingHistoryPayloadCancelled(
                bookingHistoryPayload.Cancelled.CancelledBy,
                bookingHistoryPayload.Cancelled.Reason),
            BookingHistoryPayload.PayloadOneofCase.Completed => new BookingHistoryPayloadCompleted(),
            BookingHistoryPayload.PayloadOneofCase.None => throw new InvalidOperationException("Payload is empty"),
            _ => throw new ArgumentOutOfRangeException(nameof(bookingHistoryPayload)),
        };
        return payload;
    }
}