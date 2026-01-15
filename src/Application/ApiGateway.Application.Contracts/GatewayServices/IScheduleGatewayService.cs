using ApiGateway.Application.Contracts.Schedule;

namespace ApiGateway.Application.Contracts.GatewayServices;

public interface IScheduleGatewayService
{
    Task<CreateScheduleSlotResponseDto> CreateScheduleSlotAsync(CreateScheduleSlotRequestDto requestDto);
}