namespace ApiGateway.Application.Contracts.Booking.QueryBookingHistory;

public class QueryBookingHistoryResponse
{
    public required Models.Bookings.Models.BookingHistory[] History { get; init; }
}