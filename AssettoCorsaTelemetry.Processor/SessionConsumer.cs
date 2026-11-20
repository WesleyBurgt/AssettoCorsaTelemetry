using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dtos;
using MassTransit;

namespace AssettoCorsaTelemetry.Processor;

public class SessionBatchConsumer : IConsumer<Batch<SessionReceived>>
{
    private readonly ISessionService _sessionService;

    public SessionBatchConsumer(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public async Task Consume(ConsumeContext<Batch<SessionReceived>> context)
    {
        Batch<SessionReceived> messages = context.Message;

        List<SessionReceived> records = messages
            .Select(x => x.Message)
            .ToList();

        await _sessionService.AddSessionBatchAsync(
            records,
            context.CancellationToken);
    }
}