using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Core.Services;

public class PhysicsDataService(IPhysicsDataRepository repository) : IPhysicsDataService
{
    public async Task AddPhysicsDataBatchAsync(IReadOnlyCollection<TelemetryReceived> batch, CancellationToken cancellationToken = default)
    {
        if (batch.Count == 0)
            return;

        List<PhysicsData> records = batch.Select(message => PhysicsData.FromDto(message.Data))
                                         .ToList();

        await repository.AddPhysicsDataBatchAsync(records, cancellationToken);
    }
}