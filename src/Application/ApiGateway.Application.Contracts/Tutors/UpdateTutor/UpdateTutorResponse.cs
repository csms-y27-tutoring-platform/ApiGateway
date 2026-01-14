namespace ApiGateway.Application.Contracts.Tutors.UpdateTutor;

public class UpdateTutorResponse
{
    public required string TutorId { get; init; }

    public DateTimeOffset UpdatedAt { get; init; }
}