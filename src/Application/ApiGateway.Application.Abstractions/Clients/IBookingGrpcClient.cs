using ApiGateway.Application.Contracts.Booking.CancelBooking;
using ApiGateway.Application.Contracts.Booking.CompleteBooking;
using ApiGateway.Application.Contracts.Booking.CreateBooking;
using ApiGateway.Application.Contracts.Booking.GetBooking;
using ApiGateway.Application.Contracts.Booking.QueryBookingHistory;
using ApiGateway.Application.Contracts.Booking.QueryBookings;

namespace ApiGateway.Application.Abstractions.Clients;

public interface IBookingGrpcClient
{
    Task<CreateBookingResponseDto> CreateBookingAsync(CreateBookingRequestDto requestDto);

    Task<CancelBookingResponseDto> CancelBookingAsync(CancelBookingRequestDto requestDto);

    Task<CompleteBookingResponseDto> CompleteBookingAsync(CompleteBookingRequestDto requestDto);

    Task<GetBookingResponseDto> GetBookingByIdAsync(GetBookingRequestDto requestDto);

    Task<QueryBookingsResponseDto> QueryBookingsAsync(QueryBookingsRequestDto requestDto);

    Task<QueryBookingHistoryResponseDto> QueryBookingHistoryAsync(QueryBookingHistoryRequestDto requestDto);
}
