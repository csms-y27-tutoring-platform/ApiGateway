namespace ApiGateway.Application.Contracts.Booking.QueryBookings;

public class QueryBookingsResponse
{
    public required Models.Bookings.Models.Booking[] Bookings { get; init; }
}