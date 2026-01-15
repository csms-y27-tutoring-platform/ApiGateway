using ApiGateway.Application.Contracts.Schedule;

namespace ApiGateway.Application.Abstractions.Clients;

public interface IScheduleGrpcClient
{
    Task<CreateScheduleSlotResponseDto> CreateScheduleSlotAsync(CreateScheduleSlotRequestDto requestDto);
}