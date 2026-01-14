namespace ApiGateway.Application.Contracts.Tutors.DeactivateTutor;

public class DeactivateTutorResponse
{
    public required string TutorId { get; init; }

    public DateTimeOffset DeactivatedAt { get; init; }
}