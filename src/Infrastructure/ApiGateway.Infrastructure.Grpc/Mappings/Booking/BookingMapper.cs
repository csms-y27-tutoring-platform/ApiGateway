namespace ApiGateway.Infrastructure.Grpc.Mappings.Booking;

public static class BookingMapper
{
    public static Application.Models.Bookings.Models.Booking ToApplication(this Grpc.Booking booking)
    {
        var dto = new Application.Models.Bookings.Models.Booking
        {
            BookingId = Guid.Parse(booking.BookingId),
            TutorId = Guid.Parse(booking.TutorId),
            TimeSlotId = Guid.Parse(booking.TimeSlotId),
            SubjectId = Guid.Parse(booking.SubjectId),
            Status = booking.Status.ToApplication(),
            CreatedAt = booking.CreatedAt.ToDateTimeOffset(),
            Name = booking.Name,
        };
        return dto;
    }
}