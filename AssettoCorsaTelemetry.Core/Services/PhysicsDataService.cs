using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dtos;

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
    
    public async Task AddPhysicsDataBatchAsync(IReadOnlyCollection<TelemetryReceived> batch, CancellationToken cancellationToken)
    {
        if (batch.Count == 0)
            return;

        Guid sessionId = batch.First().SessionId;

        // Resolve the session once.
        Session session = await _sessionRepository.GetByIdAsync(sessionId, cancellationToken);

        List<PhysicsData> records = batch.Select(message => new PhysicsData
        {
            Id = Guid.NewGuid(),
            Timestamp = message.Data.Timestamp,
            CarId = session.CarId,
            TrackId = session.TrackId,
            Data = UnassignedPhysicsData.FromDto(message.Data)
        }).ToList();

        await _physicsDataRepository.AddPhysicsDataBatchAsync(
            records, cancellationToken);
    }
}