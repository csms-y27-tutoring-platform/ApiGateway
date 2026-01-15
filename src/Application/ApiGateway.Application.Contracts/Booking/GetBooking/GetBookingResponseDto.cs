namespace ApiGateway.Application.Contracts.Booking.GetBooking;

public class GetBookingResponseDto
{
    public required Models.Bookings.Models.Booking Booking { get; init; }
}