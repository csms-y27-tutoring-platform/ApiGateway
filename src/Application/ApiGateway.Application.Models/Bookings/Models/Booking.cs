using ApiGateway.Application.Models.Bookings.Enums;

namespace ApiGateway.Application.Models.Bookings.Models;

public class Booking
{
    public Guid BookingId { get; init; }

    public Guid TutorId { get; init; }

    public Guid TimeSlotId { get; init; }

    public Guid SubjectId { get; init; }

    public BookingStatus? Status { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public required string Name { get; init; }
}