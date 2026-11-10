using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Core.Services;

public class PhysicsDataService : IPhysicsDataService
{
    private readonly IPhysicsDataRepository _physicsDataRepository;
    
    public PhysicsDataService(IPhysicsDataRepository physicsDataRepository)
    {
        _physicsDataRepository = physicsDataRepository;
    }
    
    public async Task AddPhysicsDataBatchAsync(IReadOnlyCollection<TelemetryReceived> batch, CancellationToken cancellationToken)
    {
        if (batch.Count == 0)
            return;

        List<PhysicsData> records = batch.Select(message => PhysicsData.FromDto(message.Data))
                                         .ToList();

        await _physicsDataRepository.AddPhysicsDataBatchAsync(records, cancellationToken);
    }
}