namespace ApiGateway.Application.Contracts.Tutors.UpdateTutor;

public class UpdateTutorResponseDto
{
    public required string TutorId { get; init; }

    public DateTimeOffset UpdatedAt { get; init; }
}