namespace ApiGateway.Application.Contracts.Booking.CancelBooking;

public class CancelBookingRequestDto
{
    public long BookingId { get; init; }

    public required string Name { get; init; }

    public required string Reason { get; init; }
}