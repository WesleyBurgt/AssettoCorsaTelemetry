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
            CarId = Guid.Empty,
            TrackId = Guid.Empty,
            Data = unassignedPhysicsData
        };
        await _repository.AddPhysicsData(data);
    }
}