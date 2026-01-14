namespace ApiGateway.Application.Contracts.Booking.CancelBooking;

public class CancelBookingRequest
{
    public long BookingId { get; init; }

    public required string Name { get; init; }

    public required string Reason { get; init; }
}