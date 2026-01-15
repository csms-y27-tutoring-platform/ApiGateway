namespace ApiGateway.Application.Contracts.Tutors.UpdateTutor;

public class UpdateTutorResponseDto
{
    public required Guid TutorId { get; init; }

    public DateTimeOffset UpdatedAt { get; init; }
}