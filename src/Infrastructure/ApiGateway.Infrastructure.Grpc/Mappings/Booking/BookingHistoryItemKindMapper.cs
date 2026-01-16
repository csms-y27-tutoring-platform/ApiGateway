namespace ApiGateway.Infrastructure.Grpc.Mappings.Booking;

public static class BookingHistoryItemKindMapper
{
    public static Application.Models.Bookings.Enums.BookingHistoryItemKind? ToApplication(
        this BookingHistoryItemKind bookingHistoryItemKind)
    {
        Application.Models.Bookings.Enums.BookingHistoryItemKind? kind = bookingHistoryItemKind switch
        {
            BookingHistoryItemKind.BookingHistoryItemCreated => Application.Models.Bookings.Enums.BookingHistoryItemKind
                .ItemCreated,
            BookingHistoryItemKind.BookingHistoryItemCancelled => Application.Models.Bookings.Enums
                .BookingHistoryItemKind.ItemCancelled,
            BookingHistoryItemKind.BookingHistoryItemCompleted => Application.Models.Bookings.Enums
                .BookingHistoryItemKind.ItemCompleted,
            BookingHistoryItemKind.BookingHistoryItemUnspecified => null,
            _ => throw new ArgumentOutOfRangeException(nameof(bookingHistoryItemKind)),
        };
        return kind;
    }

    public static BookingHistoryItemKind ToGrpc(
        this Application.Models.Bookings.Enums.BookingHistoryItemKind? bookingHistoryItemKind)
    {
        BookingHistoryItemKind kind = bookingHistoryItemKind switch
        {
            Application.Models.Bookings.Enums.BookingHistoryItemKind.ItemCreated => BookingHistoryItemKind
                .BookingHistoryItemCreated,
            Application.Models.Bookings.Enums.BookingHistoryItemKind.ItemCancelled => BookingHistoryItemKind
                .BookingHistoryItemCancelled,
            Application.Models.Bookings.Enums.BookingHistoryItemKind.ItemCompleted => BookingHistoryItemKind
                .BookingHistoryItemCompleted,
            _ => BookingHistoryItemKind.BookingHistoryItemUnspecified,
        };
        return kind;
    }
}