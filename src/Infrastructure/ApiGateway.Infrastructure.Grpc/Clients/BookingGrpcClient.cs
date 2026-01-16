using ApiGateway.Application.Abstractions.Clients;
using ApiGateway.Application.Contracts.Booking.CancelBooking;
using ApiGateway.Application.Contracts.Booking.CompleteBooking;
using ApiGateway.Application.Contracts.Booking.CreateBooking;
using ApiGateway.Application.Contracts.Booking.GetBooking;
using ApiGateway.Application.Contracts.Booking.QueryBookingHistory;
using ApiGateway.Application.Contracts.Booking.QueryBookings;
using ApiGateway.Infrastructure.Grpc.Mappings.Booking;

namespace ApiGateway.Infrastructure.Grpc.Clients;

public class BookingGrpcClient : IBookingGrpcClient
{
    private readonly BookingService.BookingServiceClient _client;

    public BookingGrpcClient(BookingService.BookingServiceClient client)
    {
        _client = client;
    }

    public async Task<CreateBookingResponseDto> CreateBookingAsync(CreateBookingRequestDto requestDto)
    {
        var request = new BookingRequest
        {
            TutorId = requestDto.TutorId.ToString(),
            TimeSlotId = requestDto.TimeSlotId.ToString(),
            SubjectId = requestDto.SubjectId.ToString(),
            Name = requestDto.Name,
        };

        BookingResponse response = await _client.CreateBookingAsync(request);

        var dto = new CreateBookingResponseDto
        {
            BookingId = Guid.Parse(response.BookingId),
        };
        return dto;
    }

    public async Task<CancelBookingResponseDto> CancelBookingAsync(CancelBookingRequestDto requestDto)
    {
        var request = new CancelBookingRequest
        {
            BookingId = requestDto.BookingId.ToString(),
            Name = requestDto.Name,
            Reason = requestDto.Reason,
        };

        CancelBookingResponse response = await _client.CancelBookingAsync(request);

        var dto = new CancelBookingResponseDto
        {
            Result = response.Result,
        };
        return dto;
    }

    public async Task<CompleteBookingResponseDto> CompleteBookingAsync(CompleteBookingRequestDto requestDto)
    {
        var request = new CompleteBookingRequest
        {
            BookingId = requestDto.BookingId.ToString(),
        };

        CompleteBookingResponse response = await _client.CompleteBookingAsync(request);

        var dto = new CompleteBookingResponseDto
        {
            Result = response.Result,
        };
        return dto;
    }

    public async Task<GetBookingResponseDto> GetBookingByIdAsync(GetBookingRequestDto requestDto)
    {
        var request = new GetBookingRequest
        {
            BookingId = requestDto.BookingId.ToString(),
        };

        GetBookingResponse response = await _client.GetBookingByIdAsync(request);

        var dto = new GetBookingResponseDto
        {
            Booking = new Application.Models.Bookings.Models.Booking
            {
                BookingId = Guid.Parse(response.Booking.BookingId),
                TutorId = Guid.Parse(response.Booking.TutorId),
                TimeSlotId = Guid.Parse(response.Booking.TimeSlotId),
                SubjectId = Guid.Parse(response.Booking.SubjectId),
                Status = response.Booking.Status.ToApplication(),
                CreatedAt = response.Booking.CreatedAt.ToDateTimeOffset(),
                Name = response.Booking.Name,
            },
        };
        return dto;
    }

    public async Task<QueryBookingsResponseDto> QueryBookingsAsync(QueryBookingsRequestDto requestDto)
    {
        var request = new QueryBookingsRequest
        {
            Status = requestDto.Status.ToGrpc(),
            Name = requestDto.Name,
            Cursor = requestDto.Cursor.ToString(),
            PageSize = requestDto.PageSize,
        };
        if (requestDto.TutorId.HasValue) request.TutorId = requestDto.TutorId.Value.ToString();
        if (requestDto.SubjectId.HasValue) request.SubjectId = requestDto.SubjectId.Value.ToString();
        request.Ids.AddRange(requestDto.Ids.Select(id => id.ToString()));

        QueryBookingsResponse response = await _client.QueryBookingsAsync(request);

        var dto = new QueryBookingsResponseDto
        {
            Bookings = response.Bookings.Select(b => b.ToApplication()).ToArray(),
        };
        return dto;
    }

    public async Task<QueryBookingHistoryResponseDto> QueryBookingHistoryAsync(QueryBookingHistoryRequestDto requestDto)
    {
        var request = new QueryBookingHistoryRequest
        {
            Kind = requestDto.Kind.ToGrpc(),
            Cursor = requestDto.Cursor.ToString(),
            PageSize = requestDto.PageSize,
        };
        request.Ids.AddRange(requestDto.Ids.Select(id => id.ToString()));

        QueryBookingHistoryResponse response = await _client.QueryBookingHistoryAsync(request);

        var dto = new QueryBookingHistoryResponseDto
        {
            History = response.History.Select(h => h.ToApplication()).ToArray(),
        };
        return dto;
    }
}