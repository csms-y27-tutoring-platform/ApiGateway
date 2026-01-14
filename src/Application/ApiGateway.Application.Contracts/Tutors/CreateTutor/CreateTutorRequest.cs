using ApiGateway.Application.Contracts.Tutors.TeachingSubject;
using ApiGateway.Application.Models.Schedule.Enums;

namespace ApiGateway.Application.Contracts.Tutors.CreateTutor;

public class CreateTutorRequest
{
    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public string? Phone { get; init; }

    public string? Description { get; init; }

    public LessonFormat PreferredFormat { get; init; }

    public int? AverageLessonDurationMinutes { get; init; }

    public required TeachingSubjectRequest[] TeachingSubjects { get; init; }
}