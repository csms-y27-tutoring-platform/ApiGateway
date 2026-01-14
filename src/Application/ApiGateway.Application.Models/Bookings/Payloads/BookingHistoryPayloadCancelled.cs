namespace ApiGateway.Application.Models.Bookings.Payloads;

public record BookingHistoryPayloadCancelled(string CancelledBy, string Reason) : BookingHistoryPayload;