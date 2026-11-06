using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dtos;
using MassTransit;

namespace AssettoCorsaTelemetry.Processor;

public class PhysicsDataBatchConsumer : IConsumer<Batch<TelemetryReceived>>
{
    private readonly IPhysicsDataService _physicsDataService;

    public PhysicsDataBatchConsumer(IPhysicsDataService physicsDataService)
    {
        _physicsDataService = physicsDataService;
    }

    public async Task Consume(ConsumeContext<Batch<TelemetryReceived>> context)
    {
        Batch<TelemetryReceived> messages = context.Message;

        List<TelemetryReceived> records = messages
            .Select(x => x.Message)
            .ToList();

        await _physicsDataService.AddPhysicsDataBatchAsync(
            records,
            context.CancellationToken);
    }
}