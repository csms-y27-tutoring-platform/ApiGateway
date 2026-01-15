namespace ApiGateway.Infrastructure.Grpc.Mappings.Booking;

public static class BookingMapper
{
    public static Application.Models.Bookings.Models.Booking ToApplication(this Grpc.Booking booking)
    {
        var dto = new Application.Models.Bookings.Models.Booking
        {
            BookingId = booking.BookingId,
            TutorId = booking.TutorId,
            TimeSlotId = booking.TimeSlotId,
            SubjectId = booking.SubjectId,
            Status = booking.Status.ToApplication(),
            CreatedAt = booking.CreatedAt.ToDateTimeOffset(),
            Name = booking.Name,
        };
        return dto;
    }
}