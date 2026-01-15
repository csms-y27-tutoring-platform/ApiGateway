using ApiGateway.Application.Abstractions.Clients;
using ApiGateway.Application.Contracts.Schedule;
using Google.Protobuf.WellKnownTypes;

namespace ApiGateway.Infrastructure.Grpc.Clients;

public class ScheduleGrpcClient : IScheduleGrpcClient
{
    private readonly ScheduleService.ScheduleServiceClient _client;

    public ScheduleGrpcClient(ScheduleService.ScheduleServiceClient client)
    {
        _client = client;
    }

    public async Task<CreateScheduleSlotResponseDto> CreateScheduleSlotAsync(CreateScheduleSlotRequestDto requestDto)
    {
        var request = new CreateScheduleSlotRequest
        {
            TutorId = requestDto.TutorId.ToString(),
            StartTime = requestDto.StartTime.ToTimestamp(),
            EndTime = requestDto.EndTime.ToTimestamp(),
        };

        CreateScheduleSlotResponse response = await _client.CreateScheduleSlotAsync(request);

        var dto = new CreateScheduleSlotResponseDto { SlotId = Guid.Parse(response.SlotId) };
        return dto;
    }
}