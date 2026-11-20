using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dtos;

namespace AssettoCorsaTelemetry.Core.Services;

public class SessionService(ISessionRepository repository, ICarService carService, ITrackService trackService) : ISessionService
{
    public async Task AddSessionBatchAsync(IReadOnlyCollection<SessionReceived> batch, CancellationToken cancellationToken = default)
    {
        if (batch.Count == 0)
            return;

        List<SessionDto> dtos = batch.Select(message => message.Data)
            .ToList();
        
        List<Session> sessions = [];
        foreach (SessionDto dto in dtos)
        {
            Session session = await FromDto(dto, cancellationToken);
            sessions.Add(session);
        }

        await repository.AddSessionBatchAsync(sessions, cancellationToken);
    }

    private async Task<Session> FromDto(SessionDto dto, CancellationToken cancellationToken = default)
    {
        Guid userId = Guid.Empty;

        Track track = await trackService.EnsureTrackExistsAsync(dto.TrackName, dto.TrackConfiguration, cancellationToken);
        
        Car car = await carService.EnsureCarExistsAsync(userId, dto.CarName, cancellationToken);

        return new Session
        {
            Id = dto.Id,
            TrackId = track.Id,
            CarId = car.Id,
            UserId = userId,
        };       
    }
}