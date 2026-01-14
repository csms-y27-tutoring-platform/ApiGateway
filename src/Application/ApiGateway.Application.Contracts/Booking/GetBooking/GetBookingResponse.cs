namespace ApiGateway.Application.Contracts.Booking.GetBooking;

public class GetBookingResponse
{
    public required Models.Bookings.Models.Booking Booking { get; init; }
}