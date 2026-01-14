namespace ApiGateway.Application.Contracts.Tutors.TeachingSubject;

public class TeachingSubjectResponse
{
    public required string TeachingSubjectId { get; init; }

    public required string SubjectId { get; init; }

    public required string SubjectName { get; init; }

    public double PricePerHour { get; init; }

    public string? Description { get; init; }

    public int ExperienceYears { get; init; }
}