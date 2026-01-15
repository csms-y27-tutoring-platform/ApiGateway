namespace ApiGateway.Application.Contracts.Schedule;

public class CreateScheduleSlotRequestDto
{
    public required string TutorId { get; init; }

    public DateTimeOffset StartTime { get; init; }

    public DateTimeOffset EndTime { get; init; }
}