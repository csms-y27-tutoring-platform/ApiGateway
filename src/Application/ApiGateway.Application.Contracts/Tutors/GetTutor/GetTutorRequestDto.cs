namespace ApiGateway.Application.Contracts.Tutors.GetTutor;

public class GetTutorRequestDto
{
    public required Guid TutorId { get; init; }
}