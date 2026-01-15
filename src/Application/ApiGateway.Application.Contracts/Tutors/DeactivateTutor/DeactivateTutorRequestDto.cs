namespace ApiGateway.Application.Contracts.Tutors.DeactivateTutor;

public class DeactivateTutorRequestDto
{
    public required Guid TutorId { get; init; }
}