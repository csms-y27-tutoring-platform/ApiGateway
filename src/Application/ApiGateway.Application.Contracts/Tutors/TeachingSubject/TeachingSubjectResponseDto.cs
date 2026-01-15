namespace ApiGateway.Application.Contracts.Tutors.TeachingSubject;

public class TeachingSubjectResponseDto
{
    public required Guid TeachingSubjectId { get; init; }

    public required Guid SubjectId { get; init; }

    public required string SubjectName { get; init; }

    public double PricePerHour { get; init; }

    public string? Description { get; init; }

    public int ExperienceYears { get; init; }
}