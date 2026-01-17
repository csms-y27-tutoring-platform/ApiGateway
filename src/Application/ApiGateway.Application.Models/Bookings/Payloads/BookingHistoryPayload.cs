using System.Text.Json.Serialization;

namespace ApiGateway.Application.Models.Bookings.Payloads;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(BookingHistoryPayloadCreated), typeDiscriminator: nameof(BookingHistoryPayloadCreated))]
[JsonDerivedType(typeof(BookingHistoryPayloadCancelled), typeDiscriminator: nameof(BookingHistoryPayloadCancelled))]
[JsonDerivedType(typeof(BookingHistoryPayloadCompleted), typeDiscriminator: nameof(BookingHistoryPayloadCompleted))]
public abstract record BookingHistoryPayload();