namespace ApiGateway.Application.Contracts.Tutors.TeachingSubject;

public class TeachingSubjectRequestDto
{
    public required string SubjectId { get; init; }

    public double PricePerHour { get; init; }

    public string? Description { get; init; }

    public int ExperienceYears { get; init; }
}