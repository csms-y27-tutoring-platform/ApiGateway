using ApiGateway.Application.Models.Bookings.Enums;

namespace ApiGateway.Application.Contracts.Booking.QueryBookings;

public class QueryBookingsRequestDto
{
    public required Guid[] Ids { get; init; }

    public Guid? TutorId { get; init; }

    public Guid? SubjectId { get; init; }

    public BookingStatus? Status { get; init; }

    public string? Name { get; init; }

    public Guid Cursor { get; init; }

    public int PageSize { get; init; }
}