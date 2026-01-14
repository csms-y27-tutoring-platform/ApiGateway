namespace ApiGateway.Application.Contracts.Schedule;

public class CreateScheduleSlotRequest
{
    public required string TutorId { get; init; }

    public DateTimeOffset StartTime { get; init; }

    public DateTimeOffset EndTime { get; init; }
}