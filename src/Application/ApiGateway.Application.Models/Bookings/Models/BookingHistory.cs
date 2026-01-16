using ApiGateway.Application.Models.Bookings.Enums;
using ApiGateway.Application.Models.Bookings.Payloads;

namespace ApiGateway.Application.Models.Bookings.Models;

public class BookingHistory
{
    public Guid BookingHistoryItemId { get; init; }

    public Guid BookingId { get; init; }

    public BookingHistoryItemKind? Kind { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public required BookingHistoryPayload? Payload { get; init; }
}