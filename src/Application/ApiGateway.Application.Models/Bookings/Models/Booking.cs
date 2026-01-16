using ApiGateway.Application.Models.Bookings.Enums;

namespace ApiGateway.Application.Models.Bookings.Models;

public class Booking
{
    public long BookingId { get; init; }

    public long TutorId { get; init; }

    public long TimeSlotId { get; init; }

    public long SubjectId { get; init; }

    public BookingStatus? Status { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public required string Name { get; init; }
}