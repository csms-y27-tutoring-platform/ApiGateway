using ApiGateway.Application.Contracts.Tutors.CreateTutor;
using ApiGateway.Application.Contracts.Tutors.DeactivateTutor;
using ApiGateway.Application.Contracts.Tutors.GetTutor;
using ApiGateway.Application.Contracts.Tutors.UpdateTutor;

namespace ApiGateway.Application.Contracts.GatewayServices;

public interface ITutorGatewayService
{
    Task<CreateTutorResponseDto> CreateTutorAsync(CreateTutorRequestDto requestDto);

    Task<UpdateTutorResponseDto> UpdateTutorAsync(UpdateTutorRequestDto requestDto);

    Task<GetTutorResponseDto> GetTutorAsync(GetTutorRequestDto requestDto);

    Task<DeactivateTutorResponseDto> DeactivateTutor(DeactivateTutorRequestDto requestDto);
}