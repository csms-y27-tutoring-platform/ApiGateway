namespace ApiGateway.Application.Contracts.Booking.QueryBookings;

public class QueryBookingsResponseDto
{
    public required Models.Bookings.Models.Booking[] Bookings { get; init; }
}