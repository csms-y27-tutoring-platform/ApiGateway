using ApiGateway.Application.Models.Bookings.Enums;

namespace ApiGateway.Application.Contracts.Booking.QueryBookingHistory;

public class QueryBookingHistoryRequestDto
{
    public required Guid[] Ids { get; init; }

    public BookingHistoryItemKind? Kind { get; init; }

    public Guid Cursor { get; init; }

    public int PageSize { get; init; }
}