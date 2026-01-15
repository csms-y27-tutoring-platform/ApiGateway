using ApiGateway.Application.Abstractions.Clients;
using ApiGateway.Application.Contracts.GatewayServices;
using ApiGateway.Application.Contracts.Tutors.CreateTutor;
using ApiGateway.Application.Contracts.Tutors.DeactivateTutor;
using ApiGateway.Application.Contracts.Tutors.GetTutor;
using ApiGateway.Application.Contracts.Tutors.UpdateTutor;

namespace ApiGateway.Application.Services;

public class TutorGatewayService : ITutorGatewayService
{
    private readonly ITutorGrpcClient _client;

    public TutorGatewayService(ITutorGrpcClient client)
    {
        _client = client;
    }

    public async Task<CreateTutorResponseDto> CreateTutorAsync(CreateTutorRequestDto requestDto)
    {
        if (string.IsNullOrWhiteSpace(requestDto.FirstName))
        {
            throw new ArgumentException("First name is required");
        }

        if (string.IsNullOrWhiteSpace(requestDto.LastName))
        {
            throw new ArgumentException("Last name is required");
        }

        if (string.IsNullOrWhiteSpace(requestDto.Email))
        {
            throw new ArgumentException("Email is required");
        }

        if (requestDto.TeachingSubjects.Length == 0)
        {
            throw new ArgumentException("Teaching subjects is required");
        }

        return await _client.CreateTutorAsync(requestDto);
    }

    public async Task<UpdateTutorResponseDto> UpdateTutorAsync(UpdateTutorRequestDto requestDto)
    {
        if (requestDto.TutorId == Guid.Empty)
        {
            throw new ArgumentException("Invalid Id. Id must be greater than zero");
        }

        return await _client.UpdateTutorAsync(requestDto);
    }

    public async Task<GetTutorResponseDto> GetTutorAsync(GetTutorRequestDto requestDto)
    {
        if (requestDto.TutorId == Guid.Empty)
        {
            throw new ArgumentException("Invalid Id. Id must be greater than zero");
        }

        return await _client.GetTutorAsync(requestDto);
    }

    public async Task<DeactivateTutorResponseDto> DeactivateTutor(DeactivateTutorRequestDto requestDto)
    {
        if (requestDto.TutorId == Guid.Empty)
        {
            throw new ArgumentException("Invalid Id. Id must be greater than zero");
        }

        return await _client.DeactivateTutor(requestDto);
    }
}