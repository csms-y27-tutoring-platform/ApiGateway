namespace ApiGateway.Application.Contracts.Booking.CreateBooking;

public class CreateBookingRequestDto
{
    public Guid TutorId { get; init; }

    public Guid TimeSlotId { get; init; }

    public Guid SubjectId { get; init; }

    public required string Name { get; init; }
}