using ApiGateway.Application.Abstractions.Clients;
using ApiGateway.Application.Contracts.GatewayServices;
using ApiGateway.Application.Contracts.Schedule;

namespace ApiGateway.Application.Services;

public class ScheduleGatewayService : IScheduleGatewayService
{
    private readonly IScheduleGrpcClient _client;

    public ScheduleGatewayService(IScheduleGrpcClient client)
    {
        _client = client;
    }

    public async Task<CreateScheduleSlotResponseDto> CreateScheduleSlotAsync(CreateScheduleSlotRequestDto requestDto)
    {
        if (requestDto.TutorId == Guid.Empty)
        {
            throw new ArgumentException("Invalid Id. Id must be greater than zero");
        }

        if (requestDto.StartTime >= requestDto.EndTime)
        {
            throw new ArgumentException("Start time must be earlier than EndTime");
        }

        if (requestDto.StartTime < DateTimeOffset.UtcNow)
        {
            throw new ArgumentException("Cannot create a new schedule slot in the past");
        }

        return await _client.CreateScheduleSlotAsync(requestDto);
    }
}