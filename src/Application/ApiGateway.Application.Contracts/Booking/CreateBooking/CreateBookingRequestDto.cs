namespace ApiGateway.Application.Contracts.Booking.CreateBooking;

public class CreateBookingRequestDto
{
    public long TutorId { get; init; }

    public long TimeSlotId { get; init; }

    public long SubjectId { get; init; }

    public required string Name { get; init; }
}