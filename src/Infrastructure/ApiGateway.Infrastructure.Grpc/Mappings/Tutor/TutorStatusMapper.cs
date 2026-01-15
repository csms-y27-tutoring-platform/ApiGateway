namespace ApiGateway.Infrastructure.Grpc.Mappings.Tutor;

public static class TutorStatusMapper
{
    public static Application.Models.Tutors.Enums.TutorStatus ToApplication(this TutorStatus tutorStatus)
    {
        Application.Models.Tutors.Enums.TutorStatus status = tutorStatus switch
        {
            TutorStatus.Active => Application.Models.Tutors.Enums.TutorStatus.Active,
            TutorStatus.Inactive => Application.Models.Tutors.Enums.TutorStatus.Inactive,
            TutorStatus.Suspended => Application.Models.Tutors.Enums.TutorStatus.Suspended,
            TutorStatus.Deleted => Application.Models.Tutors.Enums.TutorStatus.Deleted,
            _ => throw new ArgumentOutOfRangeException(nameof(tutorStatus)),
        };
        return status;
    }
}