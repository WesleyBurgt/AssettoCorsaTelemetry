using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;

namespace AssettoCorsaTelemetry.Core.Services;

public class PhysicsDataService : IPhysicsDataService
{
    private readonly IPhysicsDataRepository _repository;
    
    public PhysicsDataService(IPhysicsDataRepository repository)
    {
        _repository = repository;
    }

    public async Task AddPhysicsDataAsync(UnassignedPhysicsData unassignedPhysicsData)
    {
        PhysicsData data = new PhysicsData
        {
            Id = Guid.NewGuid(),
            Timestamp = unassignedPhysicsData.Timestamp,
            CarId = Guid.Empty,
            TrackId = Guid.Empty,
            Data = unassignedPhysicsData
        };
        await _repository.AddPhysicsData(data);
    }
    
    public async Task AddPhysicsDataBatchAsync(IReadOnlyCollection<UnassignedPhysicsData> batch, CancellationToken cancellationToken = default)
    {
        if (batch.Count == 0)
            return;

        List<PhysicsData> records = batch.Select(data => new PhysicsData
        {
            Id = Guid.NewGuid(),
            Timestamp = data.Timestamp,
            CarId = Guid.Empty,
            TrackId = Guid.Empty,
            Data = data
        }).ToList();

        await _repository.AddPhysicsDataBatchAsync(records, cancellationToken);
    }
}