namespace ApiGateway.Application.Contracts.Tutors.DeactivateTutor;

public class DeactivateTutorResponseDto
{
    public required Guid TutorId { get; init; }

    public DateTimeOffset DeactivatedAt { get; init; }
}