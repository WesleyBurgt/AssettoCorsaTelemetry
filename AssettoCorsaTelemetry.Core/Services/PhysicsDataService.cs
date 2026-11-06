using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;

namespace AssettoCorsaTelemetry.Core.Services;

public class PhysicsDataService : IPhysicsDataService
{
    private readonly IPhysicsDataRepository _physicsDataRepository;
    private readonly ISessionRepository _sessionRepository;
    
    public PhysicsDataService(IPhysicsDataRepository physicsDataRepository, ISessionRepository sessionRepository)
    {
        _physicsDataRepository = physicsDataRepository;
        _sessionRepository = sessionRepository;
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
        await _physicsDataRepository.AddPhysicsData(data);
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

        await _physicsDataRepository.AddPhysicsDataBatchAsync(
            records, cancellationToken);
    }
}