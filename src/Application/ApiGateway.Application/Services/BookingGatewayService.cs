using ApiGateway.Application.Abstractions.Clients;
using ApiGateway.Application.Contracts.Booking.CancelBooking;
using ApiGateway.Application.Contracts.Booking.CompleteBooking;
using ApiGateway.Application.Contracts.Booking.CreateBooking;
using ApiGateway.Application.Contracts.Booking.GetBooking;
using ApiGateway.Application.Contracts.Booking.QueryBookingHistory;
using ApiGateway.Application.Contracts.Booking.QueryBookings;
using ApiGateway.Application.Contracts.GatewayServices;

namespace ApiGateway.Application.Services;

public class BookingGatewayService : IBookingGatewayService
{
    private readonly IBookingGrpcClient _client;

    public BookingGatewayService(IBookingGrpcClient client)
    {
        _client = client;
    }

    public async Task<CreateBookingResponseDto> CreateBookingAsync(CreateBookingRequestDto requestDto)
    {
        if (requestDto.TutorId == Guid.Empty || requestDto.TimeSlotId == Guid.Empty || requestDto.SubjectId == Guid.Empty)
        {
            throw new ArgumentException("Id is can't be empty");
        }

        if (string.IsNullOrWhiteSpace(requestDto.Name))
        {
            throw new ArgumentException("Name is required");
        }

        return await _client.CreateBookingAsync(requestDto);
    }

    public async Task<CancelBookingResponseDto> CancelBookingAsync(CancelBookingRequestDto requestDto)
    {
        if (requestDto.BookingId == Guid.Empty)
        {
            throw new ArgumentException("Id is can't be empty");
        }

        if (string.IsNullOrWhiteSpace(requestDto.Name))
        {
            throw new ArgumentException("Name is required");
        }

        if (string.IsNullOrWhiteSpace(requestDto.Reason))
        {
            throw new ArgumentException("Name is required");
        }

        return await _client.CancelBookingAsync(requestDto);
    }

    public async Task<CompleteBookingResponseDto> CompleteBookingAsync(CompleteBookingRequestDto requestDto)
    {
        if (requestDto.BookingId == Guid.Empty)
        {
            throw new ArgumentException("Id is can't be empty");
        }

        return await _client.CompleteBookingAsync(requestDto);
    }

    public async Task<GetBookingResponseDto> GetBookingByIdAsync(GetBookingRequestDto requestDto)
    {
        if (requestDto.BookingId == Guid.Empty)
        {
            throw new ArgumentException("Id is can't be empty");
        }

        return await _client.GetBookingByIdAsync(requestDto);
    }

    public async Task<QueryBookingsResponseDto> QueryBookingsAsync(QueryBookingsRequestDto requestDto)
    {
        if (requestDto.Ids.Length == 0)
        {
            throw new ArgumentException("At least one Id is required");
        }

        if (requestDto.Ids.Any(id => id == Guid.Empty))
        {
            throw new ArgumentException("Id is can't be empty");
        }

        if (requestDto.TutorId.HasValue && requestDto.TutorId == Guid.Empty)
        {
            throw new ArgumentException("Id is can't be empty");
        }

        if (requestDto.SubjectId.HasValue && requestDto.SubjectId == Guid.Empty)
        {
            throw new ArgumentException("Id is can't be empty");
        }

        if (requestDto.Cursor == Guid.Empty)
        {
            throw new ArgumentException("Cursor is can't be empty");
        }

        if (requestDto.PageSize <= 0)
        {
            throw new ArgumentException("PageSize must be greater than zero");
        }

        return await _client.QueryBookingsAsync(requestDto);
    }

    public async Task<QueryBookingHistoryResponseDto> QueryBookingHistoryAsync(QueryBookingHistoryRequestDto requestDto)
    {
        if (requestDto.Ids.Any(id => id == Guid.Empty))
        {
            throw new ArgumentException("Id is can't be empty");
        }

        if (requestDto.Ids.Length == 0)
        {
            throw new ArgumentException("At least one Id is required");
        }

        if (requestDto.Cursor == Guid.Empty)
        {
            throw new ArgumentException("Cursor is can't be empty");
        }

        if (requestDto.PageSize <= 0)
        {
            throw new ArgumentException("PageSize must be greater than zero");
        }

        return await _client.QueryBookingHistoryAsync(requestDto);
    }
}