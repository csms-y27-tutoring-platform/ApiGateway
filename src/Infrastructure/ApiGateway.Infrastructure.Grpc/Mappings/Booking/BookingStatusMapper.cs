namespace ApiGateway.Infrastructure.Grpc.Mappings.Booking;

public static class BookingStatusMapper
{
    public static Application.Models.Bookings.Enums.BookingStatus ToApplication(this BookingStatus bookingStatus)
    {
        Application.Models.Bookings.Enums.BookingStatus status = bookingStatus switch
        {
            BookingStatus.BookingCreated => Application.Models.Bookings.Enums.BookingStatus.Created,
            BookingStatus.BookingCancelled => Application.Models.Bookings.Enums.BookingStatus.Cancelled,
            BookingStatus.BookingCompleted => Application.Models.Bookings.Enums.BookingStatus.Completed,
            BookingStatus.BookingUnspecified => throw new InvalidOperationException("Status is empty"),
            _ => throw new ArgumentOutOfRangeException(nameof(bookingStatus)),
        };
        return status;
    }

    public static BookingStatus ToGrpc(this Application.Models.Bookings.Enums.BookingStatus? bookingStatus)
    {
        BookingStatus status = bookingStatus switch
        {
            Application.Models.Bookings.Enums.BookingStatus.Created => BookingStatus.BookingCreated,
            Application.Models.Bookings.Enums.BookingStatus.Cancelled => BookingStatus.BookingCancelled,
            Application.Models.Bookings.Enums.BookingStatus.Completed => BookingStatus.BookingCompleted,
            _ => BookingStatus.BookingUnspecified,
        };
        return status;
    }
}