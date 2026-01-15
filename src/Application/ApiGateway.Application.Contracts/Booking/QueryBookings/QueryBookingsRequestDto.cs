using ApiGateway.Application.Models.Bookings.Enums;

namespace ApiGateway.Application.Contracts.Booking.QueryBookings;

public class QueryBookingsRequestDto
{
    public required long[] Ids { get; init; }

    public long? TutorId { get; init; }

    public long? SubjectId { get; init; }

    public BookingStatus? Status { get; init; }

    public string? Name { get; init; }

    public long Cursor { get; init; }

    public int PageSize { get; init; }
}