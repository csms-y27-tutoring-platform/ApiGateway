using ApiGateway.Application.Contracts.Booking.CancelBooking;
using ApiGateway.Application.Contracts.Booking.CompleteBooking;
using ApiGateway.Application.Contracts.Booking.CreateBooking;
using ApiGateway.Application.Contracts.Booking.GetBooking;
using ApiGateway.Application.Contracts.Booking.QueryBookingHistory;
using ApiGateway.Application.Contracts.Booking.QueryBookings;
using ApiGateway.Application.Contracts.GatewayServices;
using ApiGateway.Application.Models.Bookings.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Presentation.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly IBookingGatewayService _service;

    public BookingController(IBookingGatewayService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateBookingResponseDto>> CreateBookingAsync(
        [FromBody] CreateBookingRequestDto request)
    {
        CreateBookingResponseDto response = await _service.CreateBookingAsync(request);
        return Ok(response);
    }

    [HttpPost("{id:long}/cancel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CancelBookingResponseDto>> CancelBookingAsync(
        [FromRoute] long id,
        [FromBody] CancelBookingRequestDto body)
    {
        var request = new CancelBookingRequestDto
        {
            BookingId = id,
            Name = body.Name,
            Reason = body.Reason,
        };
        CancelBookingResponseDto response = await _service.CancelBookingAsync(request);
        return Ok(response);
    }

    [HttpPost("{id:long}/complete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CompleteBookingResponseDto>> CompleteBookingAsync(
        [FromRoute] long id)
    {
        var request = new CompleteBookingRequestDto
        {
            BookingId = id,
        };
        CompleteBookingResponseDto result = await _service.CompleteBookingAsync(request);
        return Ok(result);
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetBookingResponseDto>> GetBookingAsync(
        [FromRoute] long id)
    {
        var request = new GetBookingRequestDto { BookingId = id };
        GetBookingResponseDto response = await _service.GetBookingByIdAsync(request);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<QueryBookingsResponseDto>> QueryBookings(
        [FromQuery] long[] ids,
        [FromQuery] long? tutorId,
        [FromQuery] long? subjectId,
        [FromQuery] BookingStatus? status,
        [FromQuery] string? createdBy,
        [FromQuery] long cursor = 0,
        [FromQuery] int pageSize = 10)
    {
        var request = new QueryBookingsRequestDto
        {
            Ids = ids,
            TutorId = tutorId,
            SubjectId = subjectId,
            Status = status,
            Name = createdBy,
            Cursor = cursor,
            PageSize = pageSize,
        };
        QueryBookingsResponseDto response = await _service.QueryBookingsAsync(request);
        return Ok(response);
    }

    [HttpGet("history")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<QueryBookingHistoryResponseDto>> QueryHistoryAsync(
        [FromQuery] long[] ids,
        [FromQuery] BookingHistoryItemKind? kind,
        [FromQuery] long cursor = 0,
        [FromQuery] int pageSize = 10)
    {
        var request = new QueryBookingHistoryRequestDto
        {
            Ids = ids,
            Kind = kind,
            Cursor = cursor,
            PageSize = pageSize,
        };
        QueryBookingHistoryResponseDto response = await _service.QueryBookingHistoryAsync(request);
        return Ok(response);
    }
}