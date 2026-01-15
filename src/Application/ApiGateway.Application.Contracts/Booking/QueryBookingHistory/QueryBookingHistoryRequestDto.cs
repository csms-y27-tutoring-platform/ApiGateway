using ApiGateway.Application.Models.Bookings.Enums;

namespace ApiGateway.Application.Contracts.Booking.QueryBookingHistory;

public class QueryBookingHistoryRequestDto
{
    public required long[] Ids { get; init; }

    public BookingHistoryItemKind? Kind { get; init; }

    public long Cursor { get; init; }

    public int PageSize { get; init; }
}