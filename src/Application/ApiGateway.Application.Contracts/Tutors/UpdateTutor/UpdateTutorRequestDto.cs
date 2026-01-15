using ApiGateway.Application.Contracts.Tutors.TeachingSubject;
using ApiGateway.Application.Models.Schedule.Enums;

namespace ApiGateway.Application.Contracts.Tutors.UpdateTutor;

public class UpdateTutorRequestDto
{
    public required string TutorId { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public string? Phone { get; init; }

    public string? Description { get; init; }

    public LessonFormat PreferredFormat { get; init; }

    public int? AverageLessonDurationMinutes { get; init; }

    public required TeachingSubjectRequestDto[] TeachingSubjects { get; init; }
}