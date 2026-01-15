using ApiGateway.Application.Abstractions.Clients;
using ApiGateway.Application.Contracts.Tutors.CreateTutor;
using ApiGateway.Application.Contracts.Tutors.DeactivateTutor;
using ApiGateway.Application.Contracts.Tutors.GetTutor;
using ApiGateway.Application.Contracts.Tutors.UpdateTutor;
using ApiGateway.Infrastructure.Grpc.Mappings.Tutor;

namespace ApiGateway.Infrastructure.Grpc.Clients;

public class TutorGrpcClient : ITutorGrpcClient
{
    private readonly TutorService.TutorServiceClient _client;

    public TutorGrpcClient(TutorService.TutorServiceClient client)
    {
        _client = client;
    }

    public async Task<CreateTutorResponseDto> CreateTutorAsync(CreateTutorRequestDto requestDto)
    {
        var request = new CreateTutorRequest
        {
            FirstName = requestDto.FirstName,
            LastName = requestDto.LastName,
            Email = requestDto.Email,
            Phone = requestDto.Phone,
            Description = requestDto.Description,
            PreferredFormat = requestDto.PreferredFormat.ToGrpc(),
        };
        if (requestDto.AverageLessonDurationMinutes.HasValue)
        {
            request.AverageLessonDurationMinutes = requestDto.AverageLessonDurationMinutes.Value;
        }

        request.TeachingSubjects.AddRange(requestDto.TeachingSubjects.Select(ts => ts.ToGrpc()));

        CreateTutorResponse response = await _client.CreateTutorAsync(request);

        var dto = new CreateTutorResponseDto
        {
            TutorId = Guid.Parse(response.TutorId),
            FullName = response.FullName,
            Email = response.Email,
            Status = response.Status.ToApplication(),
            CreatedAt = response.CreatedAt.ToDateTimeOffset(),
        };
        return dto;
    }

    public async Task<UpdateTutorResponseDto> UpdateTutorAsync(UpdateTutorRequestDto requestDto)
    {
        var request = new UpdateTutorRequest
        {
            TutorId = requestDto.TutorId.ToString(),
            FirstName = requestDto.FirstName,
            LastName = requestDto.LastName,
            Phone = requestDto.Phone,
            Description = requestDto.Description,
            PreferredFormat = requestDto.PreferredFormat.ToGrpc(),
        };
        if (requestDto.AverageLessonDurationMinutes.HasValue)
        {
            request.AverageLessonDurationMinutes = requestDto.AverageLessonDurationMinutes.Value;
        }

        request.TeachingSubjects.AddRange(requestDto.TeachingSubjects.Select(ts => ts.ToGrpc()));

        UpdateTutorResponse response = await _client.UpdateTutorAsync(request);

        var dto = new UpdateTutorResponseDto
        {
            TutorId = Guid.Parse(response.TutorId),
            UpdatedAt = response.UpdatedAt.ToDateTimeOffset(),
        };
        return dto;
    }

    public async Task<GetTutorResponseDto> GetTutorAsync(GetTutorRequestDto requestDto)
    {
        var request = new GetTutorRequest { TutorId = requestDto.TutorId.ToString() };

        GetTutorResponse response = await _client.GetTutorAsync(request);

        var dto = new GetTutorResponseDto
        {
            TutorId = Guid.Parse(response.TutorId),
            FirstName = response.FirstName,
            LastName = response.LastName,
            Email = response.Email,
            Phone = response.Phone,
            Description = response.Description,
            Status = response.Status.ToApplication(),
            PreferredFormat = response.PreferredFormat.ToApplication(),
            AverageLessonDurationMinutes = response.AverageLessonDurationMinutes,
            TeachingSubjects = response.TeachingSubjects.Select(ts => ts.ToApplication()).ToArray(),
            CreatedAt = response.CreatedAt.ToDateTimeOffset(),
            UpdatedAt = response.UpdatedAt.ToDateTimeOffset(),
        };
        return dto;
    }

    public async Task<DeactivateTutorResponseDto> DeactivateTutor(DeactivateTutorRequestDto requestDto)
    {
        var request = new DeactivateTutorRequest { TutorId = requestDto.TutorId.ToString() };

        DeactivateTutorResponse response = await _client.DeactivateTutorAsync(request);

        var dto = new DeactivateTutorResponseDto
        {
            TutorId = Guid.Parse(response.TutorId),
            DeactivatedAt = response.DeactivatedAt.ToDateTimeOffset(),
        };
        return dto;
    }
}