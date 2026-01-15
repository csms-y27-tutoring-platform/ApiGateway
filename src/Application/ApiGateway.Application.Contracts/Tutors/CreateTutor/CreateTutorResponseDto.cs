using ApiGateway.Application.Models.Tutors.Enums;

namespace ApiGateway.Application.Contracts.Tutors.CreateTutor;

public class CreateTutorResponseDto
{
    public required Guid TutorId { get; init; }

    public required string FullName { get; init; }

    public required string Email { get; init; }

    public TutorStatus Status { get; init; }

    public DateTimeOffset CreatedAt { get; init; }
}