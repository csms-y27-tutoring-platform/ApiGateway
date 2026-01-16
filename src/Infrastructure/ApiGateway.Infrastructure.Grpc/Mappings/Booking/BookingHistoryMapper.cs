namespace ApiGateway.Infrastructure.Grpc.Mappings.Booking;

public static class BookingHistoryMapper
{
    public static Application.Models.Bookings.Models.BookingHistory ToApplication(this BookingHistory bookingHistory)
    {
        var dto = new Application.Models.Bookings.Models.BookingHistory
        {
            BookingHistoryItemId = Guid.Parse(bookingHistory.BookingHistoryItemId),
            BookingId = Guid.Parse(bookingHistory.BookingId),
            Kind = bookingHistory.Kind.ToApplication(),
            CreatedAt = bookingHistory.CreatedAt.ToDateTimeOffset(),
            Payload = bookingHistory.Payload.ToApplication(),
        };
        return dto;
    }
}