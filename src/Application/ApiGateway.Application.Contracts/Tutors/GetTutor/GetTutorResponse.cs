using ApiGateway.Application.Contracts.Tutors.TeachingSubject;
using ApiGateway.Application.Models.Schedule.Enums;
using ApiGateway.Application.Models.Tutors.Enums;

namespace ApiGateway.Application.Contracts.Tutors.GetTutor;

public class GetTutorResponse
{
    public required string TutorId { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public string? Phone { get; init; }

    public string? Description { get; init; }

    public TutorStatus Status { get; init; }

    public LessonFormat PreferredFormat { get; init; }

    public int? AverageLessonDurationMinutes { get; init; }

    public required TeachingSubjectResponse[] TeachingSubjects { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset? UpdatedAt { get; init; }
}