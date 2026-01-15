namespace ApiGateway.Application.Contracts.Booking.QueryBookingHistory;

public class QueryBookingHistoryResponseDto
{
    public required Models.Bookings.Models.BookingHistory[] History { get; init; }
}