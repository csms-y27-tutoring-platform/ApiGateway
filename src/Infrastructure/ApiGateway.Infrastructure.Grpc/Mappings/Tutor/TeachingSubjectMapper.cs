using ApiGateway.Application.Contracts.Tutors.TeachingSubject;

namespace ApiGateway.Infrastructure.Grpc.Mappings.Tutor;

public static class TeachingSubjectMapper
{
    public static TeachingSubjectRequest ToGrpc(this TeachingSubjectRequestDto dto)
    {
        var teachingSubjectRequest = new TeachingSubjectRequest
        {
            SubjectId = dto.SubjectId,
            PricePerHour = dto.PricePerHour,
            Description = dto.Description,
            ExperienceYears = dto.ExperienceYears,
        };
        return teachingSubjectRequest;
    }

    public static TeachingSubjectResponseDto ToApplication(this TeachingSubjectResponse response)
    {
        var dto = new TeachingSubjectResponseDto
        {
            TeachingSubjectId = response.TeachingSubjectId,
            SubjectId = response.SubjectId,
            SubjectName = response.SubjectName,
            PricePerHour = response.PricePerHour,
            Description = response.Description,
            ExperienceYears = response.ExperienceYears,
        };
        return dto;
    }
}